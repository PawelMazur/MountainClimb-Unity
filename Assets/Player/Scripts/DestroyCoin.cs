using UnityEngine;
using System.Collections;

public class DestroyCoin : MonoBehaviour {
    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PlayerCollision")
        {
            Debug.Log("jest Kolizja");
            Destroy(gameObject);
        }

    }*/

    void OnTriggerEnter2D(Collider2D coll)
    {
        //PlayerCollision 
        if (coll.gameObject.tag == "PlayerCollision")
        {
            Destroy(gameObject);
        }
    }
}
