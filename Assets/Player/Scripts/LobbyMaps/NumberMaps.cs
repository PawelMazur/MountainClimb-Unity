using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberMaps : MonoBehaviour {


    public static NumberMaps numberMaps;
	// Use this for initialization

    public Button [] Maps = new Button[9];

    void Awake()
    {

        if (numberMaps == null)
        {
            numberMaps = this;
        }
        if (numberMaps != this)
        {
            Destroy(gameObject);
        }
    }

    void Reset()
    {
        Maps[0] = GameObject.Find("ButtonMap1").GetComponent<Button>();
        Maps[1] = GameObject.Find("ButtonMap2").GetComponent<Button>();
        Maps[2] = GameObject.Find("ButtonMap3").GetComponent<Button>();
        Maps[3] = GameObject.Find("ButtonMap4").GetComponent<Button>();
        Maps[4] = GameObject.Find("ButtonMap5").GetComponent<Button>();
        Maps[5] = GameObject.Find("ButtonMap6").GetComponent<Button>();
        Maps[6] = GameObject.Find("ButtonMap7").GetComponent<Button>();
        Maps[7] = GameObject.Find("ButtonMap8").GetComponent<Button>();
        Maps[8] = GameObject.Find("ButtonMap9").GetComponent<Button>();

    }

	void Start () {
        //GameController.gameController.LoadGame();
        GameController.gameController.LoadMaps();
        Debug.Log("UnlockScene : " + GameController.gameController.unlockScene);
        dispableVisibleButton(GameController.gameController.unlockScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void dispableVisibleButton(int scene)
    {
        //int unloackScene = GameController.gameController.unlockScene;
        //for (int i = unloackScene; i < 9; i++)
        for (int i = scene; i < 9; i++)
        {
            Maps[i].interactable = false;
        }
    }

}
