using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component;
using Chameleon.Player.Component.Interfaces;
using Chameleon.Player.Automation.Interfaces;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Chameleon.Player
{
    [RequireComponent(typeof(PlayerMovementComponent))]
    [RequireComponent(typeof(PlayerInputComponent))]
    [RequireComponent(typeof(PlayerAnimationComponent))]
    [RequireComponent(typeof(PlayerColorComponent))]
    [RequireComponent(typeof(PlayerCameraMotionComponent))]
    [RequireComponent(typeof(PlayerAutomationComponent))]
    public class PlayerComponent : MonoBehaviour
    {
        private IPlayerMovement _movement;
        private IPlayerInput _input;
        private IPlayerAnimation _animation;
        private IPlayerColor _color;
        private IPlayerCameraMotion _motion;
        private IPlayerAutomation _automation;

        public bool IsAuto { get; set; }
        public bool IsTitle { get; set; }
        public IAutomationTimeline AutomationTimeline { get; set; }
        public float LifeTime { get; private set; }
        public int DeathCount { get; private set; }
        public int CoinCount { get; private set; }

        private bool _isGoaled;
        private bool _isPaused;
        

        public void Initialize()
        {
            _movement = this.GetComponent<PlayerMovementComponent>();
            _input = this.GetComponent<PlayerInputComponent>();
            _animation = this.GetComponent<PlayerAnimationComponent>();
            _color = this.GetComponent<PlayerColorComponent>();
            _motion = this.GetComponent<PlayerCameraMotionComponent>();
            _automation = this.GetComponent<PlayerAutomationComponent>();
            if (!IsTitle) _motion.InMotion();
        }

        public void Pause()
        {
            _isPaused = true;
        }
        public void Unpause()
        {
            _isPaused = false;
            _animation.PlayAll();
        }

        public void OnUpdate()
        {
            if (_isGoaled) return;
            if (_motion.IsPlayingDeathMotion) return;
            LifeTime += Time.deltaTime;

            if (_input.IsDownReset())
            {
                SceneManager.LoadScene("ModeSelectScene");
            }

            _color.UpdateSwapCoolTime();

            if (_movement.CheckGrounded())
            {
                _animation.AnimateLanding();
            }

            if (IsAuto)
            {
                _automation.AutomationControl(AutomationTimeline, _movement, _color, _animation);
            }
            else
            {
                if (_input.EnsureJumpInput() && _movement.JumpCount != 2)
                {
                    Time.timeScale = 1f;
                    DOTween.timeScale = 1f;
                    _movement.Jump();
                    _animation.AnimateJumping();
                }

                

                if (_input.EnsureSwapInput() && _color.SwapCoolTime >= 0.4f)
                {
                    Time.timeScale = 1f;
                    DOTween.timeScale = 1f;
                    _animation.AnimateSwapping();
                    _color.Swap();
                }
            }

            if (_input.JumpInputDownTime >= 0.25f) _movement.SetDecreasedGravity();
            else _movement.SetRestoredGravity();

            _movement.Move(IsTitle);

            
            if (_movement.CheckFall())
            {
                _motion.DeathMotion();
                _motion.ResetEffect();
                _movement.ResetPosition();
                _color.ResetColor();
                DeathCount++;
            }

            if (!_movement.CheckGroundColor(_color.PlayerColorType))
            {
                _motion.DeathMotion();
                _motion.ResetEffect();
                _movement.ResetPosition();
                _color.ResetColor();
                DeathCount++;
            }
            
        }

        public void OnGetCoin()
        {
            CoinCount++;
        }

        public void OnGoaled()
        {
            _isGoaled = true;
            _motion.GoalMotion();
            _animation.PauseAll();
            Time.timeScale = 0;
            DOVirtual.DelayedCall(1.75f, 
                () => 
                {
                    if (TutorialManager.Instance is not null)
                    {
                        TutorialManager.Instance.OnFinish();
                    }
                    PlayModeManager.Instance.OnFinish();

                });
        }
    }
}