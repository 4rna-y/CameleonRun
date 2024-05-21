using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReticleSetterComponent : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI ReticleColorRedText;
    public void OnReticleColor(Slider slider)
    {
        if (slider.tag == "Red")
        {
            ReticleColorRedText.text = slider.value.ToString();
        }
    }
}
