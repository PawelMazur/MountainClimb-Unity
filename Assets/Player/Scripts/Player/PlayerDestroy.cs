using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDestroy : MonoBehaviour {

    public Transform checkGround;
    public LayerMask whatIsGround;
    public bool ground;
    private float waitForCollision = 0;
    private float nextCollision = 3f;

    private bool restartGame = false;
    private GameController gameController;

    public Player player;

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
    }

    void FixedUpdate()
    {
        CheckCollision();

    }

    public void CheckCollision()
    {
        if (!gameController.finishGame)
        {
            ground = Physics2D.OverlapCircle(checkGround.position, 0.15f, whatIsGround);
        }
        //if (gameController.finishGame == false)
        {
            if (Time.time > waitForCollision)
            {
                waitForCollision = Time.time + nextCollision;
                if (ground)
                {
                    //GameController.gameController.playerDestroy = true;
                    //GameController.gameController.collisionWithGround = true;
                    //gameController.GameOver();

                    PlayerCanvas.canvas.SetGameStatus("Game Over");
                    Invoke("RestartGame", 3);
                    Invoke("CountingDown2", 0);
                    Invoke("CountingDown1", 1);
                    Invoke("CountingDown0", 2);
                    //Invoke("")
                    Debug.Log("Game Over");
                }
            }
        }
    }

    public void CountingDown2()
    {
        PlayerCanvas.canvas.SetLogText("" + 2);
    }

    public void CountingDown1()
    {
        PlayerCanvas.canvas.SetLogText("" + 1);
    }

    public void CountingDown0()
    {
        PlayerCanvas.canvas.SetLogText("" + 0);
    }

    public void RestartGame()
    {
        player.DestroyPlayer();
        PlayerCanvas.canvas.SetLogText(" ");
        PlayerCanvas.canvas.SetGameStatus(" ");
        gameController.RespawnPlayer();
        
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("FinishGame"))
        {
            player.WaitOnDestroyPlayer(4);
            
        }
    }
    

}
