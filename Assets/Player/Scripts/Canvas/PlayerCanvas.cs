using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour {

    public static PlayerCanvas canvas;

    [SerializeField] private Text playerScore;
    public Text gameStatus;
    public Text logText;

    void Awake()
    {
        if (canvas == null)
        {
            canvas = this;
        }
        else if (canvas != this)
        {
            Destroy(gameObject);
        }
    }

    void Reset()
    {
        playerScore = GameObject.Find("PlayerScoreText").GetComponent<Text>();
        gameStatus = GameObject.Find("GameStatusText").GetComponent<Text>();
        logText = GameObject.Find("LogText").GetComponent<Text>();
    }

    public void SetPlayerScore(string amount)
    {
        playerScore.text = amount.ToString();
    }

    public void SetGameStatus(string amount)
    {
        gameStatus.text = amount.ToString();
    }

    public void SetLogText(string amount)
    {
        logText.text = amount.ToString();
    }
  
}
