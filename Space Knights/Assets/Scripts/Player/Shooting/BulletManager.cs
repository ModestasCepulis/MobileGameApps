using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float bulletSpeed;

    public bool BulletGoingRight;
    public bool BulletGoingLeft;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 5.0f;
        Invoke("destroyTheBullet", 7);
    }

    // Update is called once per frame
    void Update()
    {
        if(BulletGoingRight)
        {
            gameObject.transform.position += transform.right * bulletSpeed * Time.deltaTime;
        }
        else if(BulletGoingLeft)
        {
            gameObject.transform.position += -transform.right * bulletSpeed * Time.deltaTime;
        }

    }

    public void destroyTheBullet()
    {
        Destroy(gameObject);
    }
}
