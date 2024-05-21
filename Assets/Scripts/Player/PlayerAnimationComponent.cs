using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Interfaces;

namespace Chameleon.Player.Component
{
    public class PlayerAnimationComponent : MonoBehaviour, IPlayerAnimation
    {
        [SerializeField] GameObject LeftArmAxis;
        [SerializeField] GameObject RightArmAxis;
        [SerializeField] GameObject LeftLegAxis;
        [SerializeField] GameObject RightLegAxis;

        private Tween _overallTween;
        private Tween _leftArmTween;
        private Tween _rightArmTween;
        private Tween _leftLegTween;
        private Tween _rightLegTween;

        private bool _isPlayingWalking;
        private bool _isPlayingJumping;
        private bool _isPlayingSwaping;

        public void AnimateJumping()
        {
            Debug.Log("Jump");
            KillAll();
            _isPlayingWalking = false;
            _isPlayingJumping = true;
            _isPlayingSwaping = false;

            _leftArmTween = LeftArmAxis.transform.DORotate(new Vector3(0, 0, -20), 0.1f).SetEase(Ease.InCubic);
            _rightArmTween = RightArmAxis.transform.DORotate(new Vector3(0, 0, -20), 0.1f).SetEase(Ease.InCubic);
            _leftLegTween = LeftLegAxis.transform.DORotate(new Vector3(0, 0, -20), 0.1f).SetEase(Ease.InCubic);
            _rightLegTween = RightLegAxis.transform.DORotate(new Vector3(0, 0, -20), 0.1f).SetEase(Ease.InCubic);
        }

        public void AnimateLanding()
        {
            if (_isPlayingJumping)
            {
                Debug.Log("Landed");
                _isPlayingJumping = false;
                KillAll();
            }

            AnimateWalking();
        }

        public void AnimateSwapping()
        {
            if (_isPlayingSwaping) return;

            KillAll();
            _isPlayingWalking = false;
            _isPlayingSwaping = true;

            _overallTween = this.transform
               .DOLocalRotate(new Vector3(0, 360f, 0), 0.4f, RotateMode.FastBeyond360)
               .SetEase(Ease.InOutCubic)
               .OnComplete(() =>
               {
                   if (!_isPlayingJumping)
                   {
                       _isPlayingSwaping = false;
                       _isPlayingWalking = true;

                       AnimateWalking();
                   }
                   else
                   {
                       _isPlayingSwaping = false;

                   }
               });
            _leftArmTween = LeftArmAxis.transform
                .DORotate(new Vector3(-85f, 0, 0), 0.2f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() =>
                {
                    _leftArmTween = LeftArmAxis.transform
                        .DORotate(new Vector3(0f, 0, 0), 0.2f)
                        .SetEase(Ease.InOutCubic)
                        .SetDelay(0.1f);
                });
            _rightArmTween = RightArmAxis.transform
                .DORotate(new Vector3(85f, 0, 0), 0.2f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() =>
                {
                    _rightArmTween = RightArmAxis.transform
                        .DORotate(new Vector3(0f, 0, 0), 0.2f)
                        .SetEase(Ease.InOutCubic)
                        .SetDelay(0.1f);
                });
            _leftLegTween = LeftLegAxis.transform
                .DORotate(new Vector3(-85f, 0, 0), 0.2f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(() =>
                {
                    _leftLegTween = LeftLegAxis.transform
                        .DORotate(new Vector3(0f, 0, 0), 0.2f)
                        .SetEase(Ease.InOutCubic)
                        .SetDelay(0.1f);
                });
            _rightLegTween = RightLegAxis.transform
                .DORotate(new Vector3(85f, 0, 0), 0.2f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(
                () =>
                {
                    _rightLegTween = RightLegAxis.transform
                        .DORotate(new Vector3(0f, 0, 0), 0.2f)
                        .SetEase(Ease.InOutCubic)
                        .SetDelay(0.1f);
                });
        }

        public void AnimateWalking()
        {
            if (_isPlayingWalking) return;
            if (_isPlayingJumping) return;
            if (_isPlayingSwaping) return;

            _isPlayingWalking = true;
            _isPlayingJumping = false;
            _isPlayingSwaping = false;

            _leftArmTween = LeftArmAxis.transform
                .DORotate(new Vector3(0, 0, 85f), 0.1f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(
                    () =>
                    {
                        Sequence seq = DOTween.Sequence();
                        seq.Append(
                            LeftArmAxis.transform
                                .DORotate(new Vector3(0, 0, -85f), 0.2f))
                                .SetEase(Ease.InOutCubic)
                                .SetLoops(-1, LoopType.Yoyo);
                        _leftArmTween = seq;
                    });

            _rightArmTween = RightArmAxis.transform
                .DORotate(new Vector3(0, 0, -85f), 0.1f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(
                    () =>
                    {
                        Sequence seq = DOTween.Sequence();
                        seq.Append(
                            RightArmAxis.transform
                                .DORotate(new Vector3(0, 0, 85f), 0.2f))
                                .SetEase(Ease.InOutCubic)
                                .SetLoops(-1, LoopType.Yoyo);
                        _rightArmTween = seq;
                    });

            _leftLegTween = LeftLegAxis.transform
                .DORotate(new Vector3(0, 0, -85f), 0.1f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(
                    () =>
                    {
                        Sequence seq = DOTween.Sequence();
                        seq.Append(
                            LeftLegAxis.transform
                                .DORotate(new Vector3(0, 0, 85f), 0.2f))
                                .SetEase(Ease.InOutCubic)
                                .SetLoops(-1, LoopType.Yoyo);
                        _leftLegTween = seq;
                    });

            _rightLegTween = RightLegAxis.transform
                .DORotate(new Vector3(0, 0, 85f), 0.1f)
                .SetEase(Ease.InOutCubic)
                .OnComplete(
                    () =>
                    {
                        Sequence seq = DOTween.Sequence();
                        seq.Append(
                            RightLegAxis.transform
                                .DORotate(new Vector3(0, 0, -85f), 0.2f))
                                .SetEase(Ease.InOutCubic)
                                .SetLoops(-1, LoopType.Yoyo);
                        _rightLegTween = seq;
                    });

        }
        public void KillAll()
        {
            _leftArmTween.Kill();
            _rightArmTween.Kill();
            _leftLegTween.Kill();
            _rightLegTween.Kill();
        }

        public void PauseAll()
        {
            _leftArmTween.Pause();
            _rightArmTween.Pause();
            _leftLegTween.Pause();
            _rightLegTween.Pause();
        }

        public void PlayAll()
        {
            _leftArmTween.Play();
            _rightArmTween.Play();
            _leftLegTween.Play();
            _rightLegTween.Play();
        }
    }
}