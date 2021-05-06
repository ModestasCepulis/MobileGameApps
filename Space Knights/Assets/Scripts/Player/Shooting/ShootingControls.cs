using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour
{
    //spots to spawn from
    public GameObject firstSpotToSpawnFrom;
    public GameObject secondSpotToSpawnFrom;
    public GameObject thirdSpotToSpawnFrom;

    //boolean
    public bool isOutflanker = false;
    public bool twoSpotsToShoot = true;
    public bool oneSpotToShoot = false;

    //timer for attacking
    private float nextAttackTime = 0;

    //strings to get prefabs from:

    public string firstBulletStringPrefabLocation;
    public string secondBulletStringPrefabLocation;
    public string thirdBulletStringPrefabLocation;

    //shooting rate
    public float shootingRate;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attackMinuses(float attackRate)
    {
        nextAttackTime = Time.time + 1.5f / attackRate;
    }

    public void setShootingRate(float shootRate)
    {
        shootingRate = shootRate;
    }

    public void shootOnButtonClicked()
    {
        if (Time.time > nextAttackTime)
        {
            attackMinuses(shootingRate);

            if(twoSpotsToShoot)
            {
                Instantiate(Resources.Load("Prefabs/" + firstBulletStringPrefabLocation), firstSpotToSpawnFrom.transform.position, Quaternion.identity);
                Instantiate(Resources.Load("Prefabs/" + secondBulletStringPrefabLocation), secondSpotToSpawnFrom.transform.position, Quaternion.identity);
            }
            if(isOutflanker)
            {
                Instantiate(Resources.Load("Prefabs/" + thirdBulletStringPrefabLocation), thirdSpotToSpawnFrom.transform.position, Quaternion.identity);
            }
            if(oneSpotToShoot)
            {
                Instantiate(Resources.Load("Prefabs/" + firstBulletStringPrefabLocation), firstSpotToSpawnFrom.transform.position, Quaternion.identity);
            }
        }
    }
}
