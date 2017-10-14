using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private GameController gameController;
    AudioSource audioSurce;
    public AudioClip audioClipEngine;

    void Start()
    {

        GameObject gameObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject != null)
        {
            gameController = gameObject.GetComponent<GameController>();
        } if (gameObject == null)
        {
            Debug.Log("Dont find script 'GameController' ");
        }

        audioSurce = GetComponent<AudioSource>();
        Invoke("AudioEngine", 4);
        
    }

    void Update()
    {
        /*
        if (gameController.finishGame == true)
        {
            WaitOnDestroyPlayer(2);
            gameController.finishGame = false;
        }*/
    }

    public void AudioEngine()
    {
        audioSurce.clip = audioClipEngine;
        audioSurce.Play();
        

    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public void WaitOnDestroyPlayer(int wait)
    {
        Destroy(gameObject, wait);
    }

    public void RestartGame()
    {
        //gameController.RespawnPlayer();
        gameController.BreakScene();
        Destroy(gameObject);
    }

    public void EndCanvas()
    {
        gameController.EndCanvas();
    }    
}
