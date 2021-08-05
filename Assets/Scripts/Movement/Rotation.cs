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


        /*
        Vector3 currentPos = new Vector3(_rigidbody.position.x, 0f, _rigidbody.position.z);
        Vector3 pointToLook = GetPointToLook();
        Vector3 targetDirection = pointToLook - currentPos;

        var forward = transform.forward;
        var localTarget = transform.InverseTransformPoint(pointToLook);

        Angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        Vector3 eulerAngleVelocity = new Vector3(0, Angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        

        
        Vector3 currentPos = new Vector3(_rigidbody.position.x, 0f, _rigidbody.position.z);
        Vector3 pointToLook = GetPointToLook();

        Vector3 currentPosForward = currentPos +  Vector3.forward;
        Vector3 pointToLookNormalized = (currentPos + pointToLook).normalized;

        float angleBetween = Angle = Vector3.SignedAngle(currentPosForward, pointToLookNormalized, currentPos + Vector3.up);
        //float angleBetween = Angle = Vector3.SignedAngle(currentPosForward, pointToLookNormalized, currentPos * Vector3.up);

        Quaternion angleToRotate = Quaternion.AngleAxis(angleBetween, currentPos + Vector3.up);
        //_rotationAngle = Quaternion.RotateTowards(_rotationAngle, angleToRotate, 180f);
            
        _rigidbody.MoveRotation(angleToRotate);

        Debug.DrawLine(currentPos, pointToLookNormalized * 2, Color.blue);
        Debug.DrawLine(currentPos, currentPos + Vector3.up * 2, Color.magenta);
        Debug.DrawLine(currentPosForward * 2, pointToLook, Color.green);
        Debug.DrawLine(currentPos, currentPosForward * 2, Color.cyan); */
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
