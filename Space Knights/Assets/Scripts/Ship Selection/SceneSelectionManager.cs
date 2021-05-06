using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectionManager : MonoBehaviour
{
    private float timeToLoadScene;
    public Animator anim;
    public string sceneName;

    public bool isLogoScene = false;
    

    public void LoadNextScene (string shipSelection)
    {
        ShipSelectionToSpawn.shipName = shipSelection;
    }

    public void assignSelectedShipCanvas(string shipSelectionCanvas)
    {
        ShipSelectionToSpawn.shipCanvas = shipSelectionCanvas;
        anim.SetBool("fadeOut", true);
        Invoke("LoadScene", timeToLoadScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeToLoadScene = 1.5f;

        if (isLogoScene)
        {
            Invoke("LoadAfterLogo", 2.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadAfterLogo()
    {
        anim.SetBool("fadeOut", true);
        Invoke("LoadScene", 3.5f);
    }

    public void loadNextSceneInTime()
    {
        anim.SetBool("fadeOut", true);
        Invoke("LoadScene", timeToLoadScene);
    }

    public void onExitButtonLoadScenePressed()
    {
        anim.SetBool("fadeOut", true);
        Invoke("exitSceneLoad", timeToLoadScene);
    }

    public void exitSceneLoad()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }
}
