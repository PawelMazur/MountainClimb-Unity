using UnityEngine;
using System.Collections;

public class CamerFollow : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    private Vector3 currentPosition;

	// Use this for initialization
	void Start () {

        //offset = new Vector3(player.transform.position.x, transform.position.y, -10);

        //offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //transform.position = player.transform.position;// +offset;
        //currentPosition = new Vector3(player.transform.position.x, transform.position.y, -10);
        transform.position = currentPosition;
        //Debug.Log("transform Player : " + currentPosition);
        //Debug.Log("trasform Camer : " + transform.position);
	}
}
