using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Interfaces;
using Chameleon.Player.Component.Enums;

namespace Chameleon.Player.Component
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementComponent : MonoBehaviour, IPlayerMovement
    {
        [SerializeField] GameObject GroundChecker;
        [SerializeField] LayerMask GroundMask;

        public int JumpCount { get; set; }
        public bool IsGrounded { get; set; }
        public float Gravity { get; set; }

        private CharacterController _charController;
        private Vector3 _velocity;
        private float _deadMoveDelayMagn = 1;
        private float _speedMagn = 0.35f;
        private bool _isPlayerInPos;

        void Start()
        {
            _charController = this.GetComponent<CharacterController>();
        }

        public bool CheckGrounded()
        {
            IsGrounded = Physics.CheckSphere(GroundChecker.transform.position, 0.1f, GroundMask);

            if (IsGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
                JumpCount = 0;
            }

            return IsGrounded && _velocity.y < 0;
        }

        public void SetRestoredGravity() => Gravity = -9.81f * 5f;

        public void SetDecreasedGravity() => Gravity = (-9.81f + 5f) * 5f;

        public void Jump()
        {
            _velocity.y = Mathf.Sqrt((3f - JumpCount) * -2f * Gravity);
            JumpCount++;
        }

        public void Move(bool isTitle = false)
        {
            _velocity.y += Gravity * Time.deltaTime;

            _charController.Move(_velocity * Time.deltaTime);

            if (!isTitle)
            {
                Vector3 selfPos = this.transform.position;
                if (_isPlayerInPos)
                {
                    Vector3 camPos = Camera.main.transform.position;
                    Camera.main.transform.position = new Vector3(
                            selfPos.x - 2.5f,
                            Mathf.Lerp(camPos.y, selfPos.y + 1.5f, 0.025f),
                            selfPos.z - 3.5f);
                }

                this.transform.position += Vector3.right * 0.4f * _deadMoveDelayMagn * _speedMagn;
                if (!_isPlayerInPos && selfPos.x - 2.5f >= Camera.main.transform.position.x)
                {
                    _isPlayerInPos = true;
                    _speedMagn = 1;
                }
            }
        }

        public void ResetPosition()
        {
            DOVirtual.DelayedCall(
                0.75f,
                () =>
                {
                    Debug.Log("Call ResetPos");
                    this.transform.position = new Vector3(-4.75f, 0.9f, 0);
                    Camera.main.transform.position = new Vector3(-2.5f, 2.5f, -3.5f);
                    Camera.main.transform.rotation = Quaternion.Euler(10, 40, 0);
                    _speedMagn = 0.35f;
                    _deadMoveDelayMagn = 1;
                    _isPlayerInPos = false;
                });
            
            
        }

        public bool CheckGroundColor(PlayerColorType type)
        {
            Vector3 self = this.transform.position;

            Debug.DrawRay(self, -Vector3.up * 0.4f);

            Ray ray = new Ray(self, -Vector3.up);
            if (Physics.Raycast(ray, out RaycastHit hit, 0.425f))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.TryGetComponent(out GroundObjectComponent g))
                {
                    if (g.GroundType == GroundType.Main && type == PlayerColorType.Swapped ||
                        g.GroundType == GroundType.Swapped && type == PlayerColorType.Main)
                    {
                        _deadMoveDelayMagn = 0;
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckFall()
        {
            if (this.transform.position.y > -5)
            {
                return false;
            }
            return true;
        }
    }
}