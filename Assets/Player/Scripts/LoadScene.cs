using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


    public int scene;
    public bool loadScene;
    public GameObject FadeOut;

    void Start()
    {
    }
    
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (GameController.gameController.finishGame == false) //&& GameController.gameController.collisionWithGround == false)
        {
            if (collider2D.CompareTag("Player"))
            {
                Debug.Log("jest kolizja ");
                //if (GameController.gameController.playerDestroy == false)
                loadScene = true;
                FadeOut.SetActive(true);
                Destroy(FadeOut, 5);
                Invoke("loadGame", 4);
                GameController.gameController.finishGame = true;
                //Destroy(collider2D);
                
            }
        }

    }

    
    public void loadGame()
    {
        Debug.Log("LoadGame: ");
        GameController.gameController.LoadNewScene(scene);
        Destroy(gameObject);
    }

    




}
