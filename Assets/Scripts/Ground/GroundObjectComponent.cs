using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectComponent : MonoBehaviour
{
    [SerializeField] public Material MainColorMaterial;
    [SerializeField] public Material SwappedColorMaterial;
    [SerializeField] private GroundType _groundType;
    public GroundType GroundType { get => _groundType; private set => SetGroundType(value); }

    private void SetGroundType(GroundType ground)
    {
        if (_groundType == ground) return;
        Renderer rd = this.GetComponent<Renderer>();

        if (ground == GroundType.Main)
            rd.material.DOColor(MainColorMaterial.color, 0.15f);
        else
            rd.material.DOColor(SwappedColorMaterial.color, 0.15f);

        _groundType = ground;
        
    }
}
