using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerHealthManager : MonoBehaviour
{
    // Start is called before the first frame update


    //player Health
    public float playerMaxHealth = 45f;
    public float playerHealth;

    //reference to save the names:
    public string shipCanvas;
    public string shipName;

    //player animator
    private Animator anim;

    //movement script reference
    private simpleMovement movement;

    //shaders to make the sprite white when taking damage:
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    //rigidbody
    private Rigidbody2D rb;

    //box collider
    private BoxCollider2D collider;

    //gravity scale
    private float gravityScale;

    private GameObject playerHealthUI;

    //UI Controls
    private GameObject UIControls;

    public HealthBar healthBar;

    private bool playerAlreadyDestroyed;

    //Animator and sprite stuff:
    //defaultsprite
    public string defaultSprite;
    public string playerDeathAnimationName;

    private GameObject PauseMenuButton;

    //joystick stuff
    //controller 
    private FixedJoystick joystick;

    void Start()
    {
        shipCanvas = ShipSelectionToSpawn.shipCanvas;
        shipName = ShipSelectionToSpawn.shipName;

        anim = GetComponent<Animator>();
        movement = GetComponent<simpleMovement>();

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Shader Graphs/"+defaultSprite); // or whatever sprite shader is being used

        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        gravityScale = Random.Range(-10, 10);

        //UI disabler
        UIControls = GameObject.FindGameObjectWithTag("Controls_Canvas");
        playerHealthUI = GameObject.FindGameObjectWithTag("UI_Player_Health");

        PauseMenuButton = GameObject.FindGameObjectWithTag("UI_PauseMenu_Button");

        healthBar = FindObjectOfType<HealthBar>();
        healthBar.setMaxHealth(playerMaxHealth);

        joystick = GameObject.FindGameObjectWithTag("JoystickController").GetComponent<FixedJoystick>();


        string mobilePath = Application.persistentDataPath;
        if (File.Exists((mobilePath + "/" + "saveData" + ".json")))
        {
            playerHealth = ShipSelectionToSpawn.shipHealth;
        }
        else
        {
            playerHealth = playerMaxHealth;
        }
        healthBar.SetHealth(playerHealth);

    }

    // Update is called once per frame
    void Update()
    {
        /*        if(playerHealth <= 0)
                {
                    StartCoroutine(Player_Zero_Health());
                }*/
        if(playerHealth == playerMaxHealth)
        {
            anim.SetBool("isDead", false);
            anim.Play("Movement");
        }

        Player_No_Health();
    }

    public void takeDamageFromEnemy(float enemyDamage)
    {
        if(playerHealth != 0)
        {
            whiteSprite();
            Invoke("normalSprite", 0.2f);
            Invoke("waitForMovement", 0.7f);
            playerHealth -= enemyDamage;
            healthBar.SetHealth(playerHealth);
        }
    }   
    
    void Player_No_Health()
    {
        if (playerHealth <= 0)
        {
            anim.SetBool("isDead", true);
            collider.enabled = false;

            playerHealthUI.SetActive(false);
            UIControls.SetActive(false);
            PauseMenuButton.GetComponent<Image>().enabled = false;

            rb.gravityScale = gravityScale;
        }
    }

     IEnumerator Player_Zero_Health()
    {
        if (playerHealth <= 0)
        {
            yield return new WaitForSeconds(0.5f);

            anim.SetBool("isDead", true);
            collider.enabled = false;

            joystick.Direction.Set(0, 0);
            joystick.Vertical.Equals(0f);
            joystick.Horizontal.Equals(0f);
            joystick.Direction.x.Equals(0);
            joystick.Direction.y.Equals(0);

            playerHealthUI.SetActive(false);
            UIControls.SetActive(false);
            PauseMenuButton.GetComponent<Image>().enabled = false;
            rb.gravityScale = gravityScale;


        }
       //StartCoroutine(Destroy_Player_Object());
    }

    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }

    void normalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
    }

    IEnumerator Destroy_Player_Object()
    {
        yield return new WaitForSeconds(1);
        //anim.Play("")
       //gameObject.SetActive(false);
    }

    public float getPlayerHealth()
    {
        return playerHealth;
    }

    public void resetPlayerHealth()
    {
        playerHealth = playerMaxHealth;
        healthBar.SetHealth(playerHealth);

    }

    public void setPlayerHealth(float value)
    {
        playerHealth = value;
    }

    public void setUIControls(bool value)
    {
        UIControls.SetActive(value);
    }

    public void setHealthControls(bool value)
    {
        playerHealthUI.SetActive(value);
    }

}
