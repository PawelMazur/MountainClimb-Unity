using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    
    public Transform target;

    private Vector3 lerpedPosition;

    void FixedUpdate() {
        
        if (target != null)
        {
            lerpedPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 2f);
            lerpedPosition.z = - 10f;
        }
        //target.position = lerpedPosition;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = lerpedPosition;
        }
    }
     
}
