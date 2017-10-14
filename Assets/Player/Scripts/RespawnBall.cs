using UnityEngine;
using System.Collections;

public class RespawnBall : MonoBehaviour {

    public GameObject ballObject;
    public Transform spawnObject;
    public float waitForRespawn;
    float timeRespawn = 0f;
    public float timeToDestroy;

    void Start(){
        
    }

    void Update()
    {
        RespawnObject();
        
    }

    void RespawnObject()
    {
        if (Time.time > timeRespawn)
        {
            timeRespawn = Time.time + waitForRespawn;
            GameObject ball = Instantiate(ballObject, spawnObject.position, spawnObject.rotation) as GameObject;
            Destroy(ball, timeToDestroy);
        }
    }

   

}
