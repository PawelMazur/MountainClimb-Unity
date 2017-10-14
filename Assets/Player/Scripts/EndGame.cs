using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("Jest Kolizja");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           
        }
    }
}
