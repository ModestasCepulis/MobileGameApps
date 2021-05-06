using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShips : MonoBehaviour
{

    public GameObject[] allTheShips;
    public int pagePosition;
    public int numberToGoTo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this is to check which spaceship is currently active and assign a value to it
        for(int i = 0; i < allTheShips.Length; i++)
        {
            if(allTheShips[i].activeInHierarchy)
            {
                pagePosition = i;
            }


        }
    }

    public void leftArrowOnButtonClick()
    {
        allTheShips[pagePosition].SetActive(false);
        if(numberToGoTo > 0)
        {
            numberToGoTo -= 1;
        }
        else
        {
            numberToGoTo = allTheShips.Length - 1;
        }
        setNextShipPageActive();

    }

    public void rightArrowOnButtonClick()
    {

        allTheShips[pagePosition].SetActive(false);
        numberToGoTo += 1;
        setNextShipPageActive();

    }

    public void setNextShipPageActive()
    {
        if (numberToGoTo < allTheShips.Length)
        {
            allTheShips[numberToGoTo].SetActive(true);
        }
        else
        {
            numberToGoTo = 0;
            allTheShips[numberToGoTo].SetActive(true);
        }
    }
}
