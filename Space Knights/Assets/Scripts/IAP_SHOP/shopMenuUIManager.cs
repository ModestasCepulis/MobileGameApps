using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopMenuUIManager : MonoBehaviour
{

    public GameObject mainMenuObject;
    public GameObject shopObject;

    public static shopMenuUIManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<shopMenuUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExitShopPressed()
    {
        shopObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }

    public void onShopButtonPressed()
    {
        mainMenuObject.SetActive(false);
        shopObject.SetActive(true);

    }


}
