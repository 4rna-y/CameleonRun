using Chameleon.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalFlagFeatureComponent : MonoBehaviour
{
    private bool _isHit;
    public bool CheckCollided()
    {
        Ray ray = new Ray(this.transform.position, Vector3.left);
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f) && !_isHit)
        {
            _isHit = true;
            hit.collider.gameObject.GetComponent<PlayerComponent>().OnGoaled();
            return true;
        }
        return false;
    }
}
