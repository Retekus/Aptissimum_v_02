using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Camera _camera;
    public Camera Camera { set { _camera = value; } }

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody { set { _rigidbody = value; } }

    [SerializeField]
    private float Angle;

    private Ray _cameraRay;
    
    public void Look()
    {

        //test
    }  

    public Vector3 GetPointToLook()
    {
        _cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        Vector3 pointToLook;

        groundPlane.Raycast(_cameraRay, out rayLength);
        pointToLook = _cameraRay.GetPoint(rayLength);
        DrawLines(pointToLook);

        return pointToLook;
    }
    private void DrawLines(Vector3 pointToLook)
    {
        Debug.DrawLine(_cameraRay.origin, pointToLook, Color.red);
        Debug.DrawLine(_cameraRay.origin, transform.position, Color.yellow);
    }

}
