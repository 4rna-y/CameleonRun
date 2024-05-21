using Chameleon.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFeatureComponent : MonoBehaviour
{
    private bool _isGot;
    public bool OnUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit, 1f) && !_isGot)
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerComponent c))
            {
                _isGot = true;
                c.OnGetCoin();
                return true;
            }
        }
        return false;
    }
}
