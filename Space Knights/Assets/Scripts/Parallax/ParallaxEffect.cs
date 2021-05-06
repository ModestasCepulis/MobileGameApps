using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    public float increaseTimeBeforeItReturns;
    public float addMoreWhereItReturns;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x + increaseTimeBeforeItReturns;
    } 

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist + addMoreWhereItReturns, transform.position.y, transform.position.z);

        if(temp > startPos + length)
        {
            startPos += length;
        }
        else if(temp < startPos - length)
        {
            startPos -= length;
        }

    }
}
