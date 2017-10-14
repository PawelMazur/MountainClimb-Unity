using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;



[System.Serializable]
class PlayerDataMaps
{
    public int unlockScene;
}

[System.Serializable]
class PlayerDataContinue
{
    public int continueScene;
}

[System.Serializable]
class PlayerData
{
    public int level;
    public int scene;

    public int unlockScene;
    public int score;
    public int life;
}





public class GameController : MonoBehaviour {

    //public GameObject playerCar;
    public GameObject ObjectBackGround;
    public GameObject ObjectEndCanvas;
    public GameObject ObjectMapsCanvas;
    public GameObject ObjectLobbyCanvas;
    public GameObject ObjectPlayer;
    public GameObject ObjectCamera;
    public GameObject ObjectCamera2;

    public GameObject mobileVirtualJoystick;
    //public GameObject playerCanvas;
    public Transform spawnPlayer;

    public int scene = 1;
    public int loadScene = 1;
    public int unlockScene = 1;
    public int continueScene = 1;

    public bool finishGame = false;
    //public bool playerDestroy = false;

    //private float waitForRespawn = 2f;
    //private float timeRespawn = 0;
    
    // Use this for initialization

    public bool collisionWithGround = false;
    public static GameController gameController;

    bool gameStart = false;

    private NumberMaps numberMaps;

    //public Image black;
    //public Animator anim;

    public Rigidbody2D rigidBodyPlayer;

    void Awake()
    {

        if (!gameStart)
        {
            gameController = this;
            //SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

            gameStart = true;
        }
    }

    public void Start()
    {
        //LoadMapsGame();
        ActiveObject();

    }

    public void Update()
    {
        /*
        if (ObjectCamera.activeSelf == false)
        {
            if (gameController.finishGame == true)
            {
                ObjectCamera2.SetActive(true);
            }
            else
            {
                ObjectCamera2.SetActive(true);
            }
        }*/
    }

    
     

    private void ActiveObject()
    {
        ObjectLobbyCanvas.SetActive(true);
        ObjectMapsCanvas.SetActive(false);
        mobileVirtualJoystick.SetActive(false);
        ObjectBackGround.SetActive(true);



    }

    public void BreakScene()
    {
        finishGame = false;
        UnloadScene(scene);
        LoadNewScene(scene);
    }
    
    public void RespawnPlayer()
    {
        finishGame = false;
        Instantiate(ObjectPlayer, spawnPlayer.position, spawnPlayer.rotation);
    }

    public void SpawnPlayer()
    {
        rigidBodyPlayer.transform.position = new Vector2(spawnPlayer.position.x, spawnPlayer.position.y);
        rigidBodyPlayer.transform.rotation = Quaternion.Euler(0, 0, 0);
    }



    public void LoadNewScene(int scene)
    {

        if (unlockScene <= scene)
        {
            unlockScene = scene;
        }
        Debug.Log("LoadNewScene : " + unlockScene);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        //RespawnPlayer();
        //SpawnPlayer();
        Invoke("RespawnPlayer", 1);
        
    }

    

    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        yield return null;
        SceneManager.UnloadScene(scene);
        
    }



    //Save and Load Game
    /*
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerCarInfo.dat", FileMode.Create);

        PlayerData playerData = new PlayerData();

        playerData.scene = scene;
        playerData.unlockScene = unlockScene;
        bf.Serialize(file, playerData);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerCarInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerCarInfo.dat", FileMode.Open);

            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            file.Close();

            scene = playerData.scene;
            unlockScene = playerData.unlockScene;

        }
    }*/

    public void SaveContinueGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerContinueInfo.dat", FileMode.Create);

        PlayerDataContinue playerDataContinue = new PlayerDataContinue();

        playerDataContinue.continueScene = scene;
        bf.Serialize(file, playerDataContinue);
        file.Close();
    }

    public void LoadContinueGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerContinueInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerContinueInfo.dat", FileMode.Open);

            PlayerDataContinue playerDataContinue = (PlayerDataContinue)bf.Deserialize(file);
            continueScene = playerDataContinue.continueScene;
            file.Close();



        }
    }

    public void SaveMaps()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerMapInfo.dat", FileMode.Create);

        PlayerDataMaps playerDataMaps = new PlayerDataMaps();

        playerDataMaps.unlockScene = unlockScene;
        bf.Serialize(file, playerDataMaps);
        file.Close();
    }

    public void LoadMaps()
    {
        Debug.Log("Map");
        if (File.Exists(Application.persistentDataPath + "/playerMapInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerMapInfo.dat", FileMode.Open);

            PlayerDataMaps playerDataMaps = (PlayerDataMaps)(bf.Deserialize(file));
            file.Close();

            unlockScene = playerDataMaps.unlockScene;
            Debug.Log("Zaladowanie Maps");

        }
    }

    //-------------------button----------------------

    public void ContinueGame()
    {
        //LoadGame();
        LoadContinueGame();
        Instantiate(ObjectPlayer, spawnPlayer.position, spawnPlayer.rotation);
        ObjectBackGround.SetActive(false);
        ObjectLobbyCanvas.SetActive(false);
        ObjectMapsCanvas.SetActive(false);
        ObjectCamera.SetActive(false);
        mobileVirtualJoystick.SetActive(true);
        Debug.Log("Scene : " + continueScene);
        SceneManager.LoadSceneAsync(continueScene, LoadSceneMode.Additive);
        scene = continueScene;
    }

    public void StartGame()
    {
        if (ObjectPlayer.activeSelf)
        {
            ObjectCamera.SetActive(true);
        }
        
        Instantiate(ObjectPlayer, spawnPlayer.position, spawnPlayer.rotation);
        ObjectBackGround.SetActive(false);
        ObjectLobbyCanvas.SetActive(false);
        ObjectMapsCanvas.SetActive(false);
        ObjectCamera.SetActive(false);
        //playerCanvas.SetActive(true);
        mobileVirtualJoystick.SetActive(true);
        //StartCoroutine(FadingIn());
        //anim.SetBool("Fade", false);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }
    

    public void NumberMaps()
    {

        if (ObjectPlayer.activeSelf)
        {
            ObjectCamera.SetActive(true);
        }

        Instantiate(ObjectPlayer, spawnPlayer.position, spawnPlayer.rotation);
        ObjectBackGround.SetActive(false);
        ObjectLobbyCanvas.SetActive(false);
        ObjectMapsCanvas.SetActive(false);
        ObjectCamera.SetActive(false);
        mobileVirtualJoystick.SetActive(true);
        SceneManager.LoadSceneAsync(loadScene, LoadSceneMode.Additive);
        scene = loadScene;
        
    }

    public void ButtonMaps()
    {
        //Debug.Log("UnlockScene : " + unlockScene);
        ObjectLobbyCanvas.SetActive(false);
        ObjectMapsCanvas.SetActive(true);
        mobileVirtualJoystick.SetActive(false);
        
        /*
        GameObject gameObject = GameObject.FindGameObjectWithTag("MapsCanvas");
        if (gameObject != null)
        {
            numberMaps = gameObject.GetComponent<NumberMaps>();
            numberMaps.dispableVisibleButton(unlockScene);
            
            if (scene > unlockScene)
            {
                numberMaps.dispableVisibleButton(scene);
            }
        }
         
        else
        {
            Debug.Log("Dont find 'Maps Canvas' ");
        }
        */    
    }

    public void ButtonBack()
    {
        ObjectLobbyCanvas.SetActive(true);
        ObjectMapsCanvas.SetActive(false);
        mobileVirtualJoystick.SetActive(false);

    }

    

    public void EndCanvas()
    {
        ObjectEndCanvas.SetActive(true);
        continueScene = scene;
    }

    public void BackGame()
    {
        ObjectEndCanvas.SetActive(false);
    }

    public void EndGame()
    {
        //SaveGame();
        SaveContinueGame();
        SaveMaps();
       
        
        ObjectBackGround.SetActive(true);
        ObjectEndCanvas.SetActive(false);
        ObjectCamera.SetActive(true);
        //UnloadScene(scene);

        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        ObjectLobbyCanvas.SetActive(true);
        ObjectMapsCanvas.SetActive(false);
        mobileVirtualJoystick.SetActive(false);

        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    

    //--------------------------------Number Button -------------------------
    public void NumberButton1()
    {
        loadScene = 1;
        NumberMaps();
    }

    public void NumberButton2()
    {
        loadScene = 2;
        NumberMaps();
    }

    public void NumberButton3()
    {
        loadScene = 3;
        NumberMaps();
    }

    public void NumberButton4()
    {
        loadScene = 4;
        NumberMaps();
    }

    public void NumberButton5()
    {
        loadScene = 5;
        NumberMaps();
    }

    public void NumberButton6()
    {
        loadScene = 6;
        NumberMaps();
    }

    public void NumberButton7()
    {
        loadScene = 7;
        NumberMaps();
    }

    public void NumberButton8()
    {
        loadScene = 8;
        NumberMaps();
    }

    public void NumberButton9()
    {
        loadScene = 9;
        NumberMaps();
    }
   
}
