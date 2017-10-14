using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public void RefreshGame()
    {
        Application.LoadLevel(Application.loadedLevel);
        
    }
}
