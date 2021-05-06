using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchingScene : MonoBehaviour
{
    // Start is called before the first frame update

    public string sceneName;
    public Animator animator;
    public float timeToChangeScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            animator.SetBool("fadeOut", true);
            Invoke("ChangeScene", timeToChangeScene);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
