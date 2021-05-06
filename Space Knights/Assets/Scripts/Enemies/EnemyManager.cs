using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{



    //Enemy Stats
    public float enemyHealth = 25;

    //animations
    private Animator anim;

    //rigidbody
    private Rigidbody2D rb;

    //box collider
    private BoxCollider2D collider;

    //gravity scale
    private float gravityScale;


    //shaders to make the sprite white when taking damage:
    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    //acess to the shooting control script:
    private ShootingControls shootinControls;

    //reference to the enemyspawner script:
    private EnemySpawner enemySpawner;

    //random attack rate
    public float attackRate = 0;

    //reference to player object:
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Shader Graphs/Small Enemy Shader"); // or whatever sprite shader is being used

        gravityScale = Random.Range(-3, 3);
        shootinControls = GetComponent<ShootingControls>();
        this.enemySpawner = FindObjectOfType<EnemySpawner>();

        attackRate = Random.Range(0.5f, 0.8f);

        playerObject = GameObject.FindGameObjectWithTag("Player");

        shootinControls.setShootingRate(attackRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            shootinControls.enabled = false;
            Invoke("EnemyDeath", 0.3f); 
        }
        if(enemyHealth > 0)
        {
           StartCoroutine(ShootAtPlayer());
        }

        if(gravityScale == 0)
        {
            gravityScale = Random.Range(-3, 3);
        }
    }

    IEnumerator ShootAtPlayer()
    {
        if (playerObject.GetComponent<PlayerHealthManager>().getPlayerHealth() > 0)
        {
            yield return new WaitForSeconds(2);
            shootinControls.shootOnButtonClicked();
        }
    }
    public void takeDamageFromPlayer(float playerDamage)
    {
        if(enemyHealth > 0)
        {
            whiteSprite();
            Invoke("normalSprite", 0.2f);
            Invoke("waitForMovement", 0.7f);
            enemyHealth -= playerDamage;
        }
    }

    public void EnemyDeath()
    {
        //animation
        anim.Play("Small_Enemy_Death");
        Invoke("Enemy_Death_Specifications", 0.5f);
    }

    public void Enemy_Death_Specifications()
    {
        collider.enabled = false;

        if(gravityScale != 0)
        {
            rb.gravityScale = gravityScale;
        }

        Invoke("DestroyTheObject", 3);

    }

    public void DestroyTheObject()
    {
        this.enemySpawner.reduceTheNumberOfActiveShips(this.enemySpawner.getNumberOfTotalShipsOnScreen() - 1);
        Destroy(gameObject);

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

}
