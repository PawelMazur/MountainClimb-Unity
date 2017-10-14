using UnityEngine;
using System.Collections;

public class CamerGo : MonoBehaviour {

    public Transform transformTartget;
    private Vector3 lerpTarget;

	// Use this for initialization
	void FixedUpdate () {

        if (transformTartget != null)
        {
            lerpTarget = Vector3.Lerp(transform.position, transformTartget.position, Time.deltaTime *2f);
            lerpTarget.z = -10f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = lerpTarget;
	}
}
