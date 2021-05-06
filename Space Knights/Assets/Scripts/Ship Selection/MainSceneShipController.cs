using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneShipController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject objectToFind = GameObject.FindGameObjectWithTag(ShipSelectionToSpawn.shipCanvas);
        objectToFind.transform.GetChild(0).gameObject.SetActive(true);

        Vector3 shipPosition = new Vector3(0, ShipSelectionToSpawn.shipPosition.y, ShipSelectionToSpawn.shipPosition.z);

        GameObject ship = Instantiate(Resources.Load<GameObject>("Prefabs/Players/" + ShipSelectionToSpawn.shipName), shipPosition, Quaternion.identity);
        ship.transform.parent = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
