using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Chameleon.Player.Component.Interfaces;
using Chameleon.Player.Component.Enums;

namespace Chameleon.Player.Component
{
    public class PlayerColorComponent : MonoBehaviour, IPlayerColor
    {
        [SerializeField] Material MainColorMaterial;
        [SerializeField] Material SwappedColorMaterial;
        [SerializeField] List<Renderer> ObjectRenderers;

        public float SwapCoolTime { get; set; }
        public PlayerColorType PlayerColorType { get; set; } = PlayerColorType.Main;

        public void Swap()
        {
            Material after;
            if (PlayerColorType == PlayerColorType.Main)
                after = SwappedColorMaterial;
            else
                after = MainColorMaterial;

            foreach (Renderer r in ObjectRenderers)
                r.material.DOColor(after.color, 0.25f).SetEase(Ease.InOutCubic);

            SwapCoolTime = 0;
            PlayerColorType = (PlayerColorType)Enum.ToObject(typeof(PlayerColorType), (int)PlayerColorType * -1);
        }

        private void ForceSwap(PlayerColorType color)
        {
            if (color == PlayerColorType.Main)
            {
                foreach (Renderer r in ObjectRenderers)
                    r.material.DOColor(MainColorMaterial.color, 0.25f).SetEase(Ease.InOutCubic);
            }
            else
            {
                foreach (Renderer r in ObjectRenderers)
                    r.material.DOColor(SwappedColorMaterial.color, 0.25f).SetEase(Ease.InOutCubic);
            }

            PlayerColorType = color;
        }

        public void UpdateSwapCoolTime()
        {
            SwapCoolTime += Time.deltaTime;
        }

        public void ResetColor()
        {
            DOVirtual.DelayedCall(0.75f, () => ForceSwap(PlayerColorType.Main));
        }
    }
}