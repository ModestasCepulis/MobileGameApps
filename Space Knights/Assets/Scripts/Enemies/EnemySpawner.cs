using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //different enemies:

    private Vector2 enemyShipSpawnPosition;
    private float randomYValueSpawnValueOne;
    private float randomYValueSpawnValueTwo;
    private float randomYSumValue;
    private float randomYSecondValue;
    private float xValueSpawn;


    //spawn rate
    public float nextSpawnTimer = 0;
    public float spawnRate;

    //name prefab for the type of enemy ship:
    public string enemyShipNameInPrefabs;

    //camera object
    private Camera mainCamera;

    //number of ships allowed at once on the screen:
    public int numberOfShipsAllowedOnScreen;
    public int totalNumberOfShips = 0;

    //reference to player object
    private GameObject playerObject;

    //previous spawn position
    public float previousSpawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         if(totalNumberOfShips < numberOfShipsAllowedOnScreen)
         {
            if(Time.time > nextSpawnTimer)
            {
                if(playerObject.GetComponent<PlayerHealthManager>().getPlayerHealth() > 0)
                {
                    spawnEnemyShip();
                }

            }

         }       
    }

    public void spawnMinuses()
    {
        nextSpawnTimer = Time.time + 1.5f / spawnRate;
    }

    public void spawnEnemyShip()
    {

        xValueSpawn = mainCamera.transform.position.x + Random.Range(10, 12);

        randomYSumValue = twoRandomYValues();
        randomYSecondValue = addRandomNumberToRandomYNumber(randomYSumValue);

            previousSpawnPosition = randomYSecondValue;
            enemyShipSpawnPosition = new Vector2(xValueSpawn, randomYSecondValue);

            Instantiate(Resources.Load("Prefabs/Enemies/" + enemyShipNameInPrefabs), enemyShipSpawnPosition, Quaternion.identity);

            spawnMinuses();
            addTotalAmountOfShips();

    }

    public float twoRandomYValues()
    {
        randomYValueSpawnValueOne = Random.Range(0, -3);
        randomYValueSpawnValueTwo = Random.Range(0, 4);

        return randomYValueSpawnValueOne + randomYValueSpawnValueTwo;
    }

    public float addRandomNumberToRandomYNumber(float randomSetYNumber)
    {
        return randomSetYNumber + Random.Range(-1f, 1f);
    }

    public void addTotalAmountOfShips()
    {
        totalNumberOfShips++;
    }

    public void reduceTheNumberOfActiveShips(int numberOfShipsRemoved)
    {
        if(totalNumberOfShips > 0)
        {
            totalNumberOfShips -= numberOfShipsRemoved;
        }

    }

    public int getNumberOfTotalShipsOnScreen()
    {
        return totalNumberOfShips;
    }
}
