using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeathManager : MonoBehaviour
{
    private PlayerHealthManager healthManager;

    private GameObject UIplayerDeath;
    private Animator animator;
    private playerDeathButtonManager deathButtonManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<PlayerHealthManager>();
        UIplayerDeath = GameObject.FindGameObjectWithTag("UI_Player_Death");
        deathButtonManager = UIplayerDeath.GetComponent<playerDeathButtonManager>();

        animator = UIplayerDeath.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enableDeathUI();
    }

    public void enableDeathUI()
    {
        if(healthManager.getPlayerHealth() <= 0)
        {
           // deathButtonManager.findReferencesAgain();
            StartCoroutine(playUIDeathAnimation());

/*            if(!UIplayerDeath.activeSelf)
            {*/
                UIplayerDeath.SetActive(true);
       //     }

        }
    }

    IEnumerator playUIDeathAnimation()
    {
        yield return new WaitForSeconds(3f);
        if (!UIplayerDeath.activeInHierarchy)
        {
           UIplayerDeath.SetActive(true);
        }

        if (healthManager.getPlayerHealth() <= 0)
        {
            //animator.SetBool("isDead", true);
            animator.Play("UI_Player_Death_Move_Up");
        }

    }

}
