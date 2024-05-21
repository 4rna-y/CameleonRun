using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

using Chameleon.Player.Component.Interfaces;
using UnityEngine.UI;

namespace Chameleon.Player.Component
{
    public class PlayerCameraMotionComponent : MonoBehaviour, IPlayerCameraMotion
    {
        [SerializeField] Volume Volume;
        private ChromaticAberration _chromaticAberration;
        private LensDistortion _lensDeistortion;
        private Camera _cam;
        public Image Curtain;

        public bool IsPlayingDeathMotion { get; private set; }

        void Start()
        {
            Volume.profile.TryGet(out _chromaticAberration);
            Volume.profile.TryGet(out _lensDeistortion);
            _cam = Camera.main;
        }

        public void InMotion()
        {
            Time.timeScale = 1.0f;
            Curtain.DOColor(new Color(1, 1, 1, 0), 0.75f);
        }

        public void DeathMotion()
        {
            IsPlayingDeathMotion = true;
            
            DOTween
                .To(
                    () => _lensDeistortion.intensity.value,
                    val => _lensDeistortion.intensity.value = val,
                    -0.75f,
                    0.2f)
                .SetEase(Ease.OutCubic);
            DOTween
                .To(
                    () => _chromaticAberration.intensity.value,
                    val => _chromaticAberration.intensity.value = val,
                    1,
                    0.2f)
                .SetEase(Ease.OutCubic);
            
        }

        public void ResetEffect()
        {
            DOVirtual.DelayedCall(0.5f, () => Curtain.DOColor(new Color(1, 1, 1, 1), 0.15f));
            DOVirtual.DelayedCall(
                0.8f,
                () =>
                {
                    
                    _lensDeistortion.intensity.value = 0;
                    _chromaticAberration.intensity.value = 0;
                    DOVirtual.DelayedCall(0.2f, () =>
                    {
                        InMotion();
                        IsPlayingDeathMotion = false;
                    });
                });
            
        }

        public void GoalMotion()
        {
            DOTween
                .To(
                    () => _lensDeistortion.intensity.value,
                    val => _lensDeistortion.intensity.value = val,
                    -0.75f,
                    1.25f)
                .SetEase(Ease.OutCubic);
            DOTween
                .To(
                    () => _chromaticAberration.intensity.value,
                    val => _chromaticAberration.intensity.value = val,
                    1,
                    1.25f)
                .SetEase(Ease.OutCubic);
        }
    }
}