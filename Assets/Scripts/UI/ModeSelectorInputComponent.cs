using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelectorInputComponent : MonoBehaviour
{
    public bool IsDownShift() => Input.GetKeyDown(KeyCode.LeftShift);
    public bool IsDownSpace() => Input.GetKeyDown(KeyCode.Space);
}
