using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UnLoadScene : MonoBehaviour {

    public int scene;
    public GameObject Fade;

    public void Awake()
    {
        GameController.gameController.UnloadScene(scene);
    }

    void Start()
    {
        Fade.SetActive(true);
        Destroy(Fade, 1);
    }
}
