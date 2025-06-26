using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera _fpsCamera;
    private Ray _Ray;
    private RaycastHit _hit; 

    [SerializeField] private float _maxDistanceRay;

    private void update()
    {
        Ray();
        DrawRay();
    }

    private void Ray()
    {
        _Ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2 ));
    }

    private void DrawRay()
    {
        if(Physics.Raycast(_Ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_Ray.origin, _Ray.direction * _maxDistanceRay, Color.blue);
        }

        if(_hit.transform == null)
        {
            Debug.DrawRay(_Ray.origin, _Ray.direction * _maxDistanceRay, Color.red);
        }
    }
}
