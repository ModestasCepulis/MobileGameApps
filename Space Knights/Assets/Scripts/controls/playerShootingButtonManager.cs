using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerShootingButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerObject;
    private ShootingControls shootControls;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onShootingButtonClicked()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        shootControls = playerObject.GetComponent<ShootingControls>();
        shootControls.shootOnButtonClicked();
    }
}
