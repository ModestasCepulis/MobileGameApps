using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public static bool isGameSupposedToBePaused;
    private Animator animator;

    private Animator attention_animator;

    private GameObject playerHealthUI;
    private GameObject UIControls;
    private GameObject PauseMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        attention_animator = GameObject.FindGameObjectWithTag("Attention").GetComponent<Animator>();

        UIControls = GameObject.FindGameObjectWithTag("Controls_Canvas");
        playerHealthUI = GameObject.FindGameObjectWithTag("UI_Player_Health");
        PauseMenuButton = GameObject.FindGameObjectWithTag("UI_PauseMenu_Button");
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameSupposedToBePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void onPauseMenuButtonClicked()
    {
        isGameSupposedToBePaused = true;
        UIControls.SetActive(false);
        playerHealthUI.SetActive(false);
        PauseMenuButton.SetActive(false);
        animator.Play("Move_Up");
    }

    public void onContinueButtonClicked()
    {
        animator.Play("PauseMenu_Idle");
        isGameSupposedToBePaused = false;
        UIControls.SetActive(true);
        playerHealthUI.SetActive(true);
        PauseMenuButton.SetActive(true);
    }

    public void onOkAttentionButtonClicked()
    {
        animator.Play("Attention_Go_Down");
    }



}
