using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultInputComponent : MonoBehaviour
{
    public bool IsKeyDownSpace() => Input.GetKeyDown(KeyCode.Space);
}
