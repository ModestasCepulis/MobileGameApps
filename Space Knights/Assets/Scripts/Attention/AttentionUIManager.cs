using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class AttentionUIManager : MonoBehaviour
{
    public TMP_Text Attention_Text_Object;
    public TMP_Text Continue_Text_Object;
    public Animator animator;

    public Animator Attention_animator;
    public Animator Continue_Animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("BlackFadeOut").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onOkButtonPressed()
    {
        Attention_animator.Play("Attention_Go_Down");
    }    

    public void fileDoesNotExistAttention()
    {
        Attention_animator.Play("Attention_Go_Up");
    }

    public void fileAlreadyExistsAttention()
    {
        Continue_Text_Object.text = "Starting a new game will overwrite the existing game save!";
        Continue_Animator.Play("Attention_Go_Up");
    }

    public void onYesAttentionButtonPressed()
    {
        //string mobilePath = Application.persistentDataPath;
/*        #if UNITY_ANDROID
            System.IO.File.Delete("/private" + mobilePath + "/" + "saveData" + ".json");
        #endif
        #if UNITY_EDITOR
        System.IO.File.Delete((mobilePath + "/" + "saveData" + ".json"));
        #endif*/
        animator.SetBool("fadeOut", true);
        Invoke("LoadScene", 1.5f);

    }

    public void LoadScene()
    {
        SceneManager.LoadScene("IconSelectionScene");
    }

    public void onNoAttentionButtonPressed()
    {
        Continue_Animator.Play("Attention_Go_Down");
    }
}
