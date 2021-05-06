using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    public string mobilePath;

    //public Animator attentionAnimator;

    private void Awake()
    {
       // SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
    }
    // Start is called before the first frame update
    void Start()
    {
      // attentionAnimator = GameObject.FindGameObjectWithTag("Attention").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class SaveObject
    {
        public string name;
        public float health;
        public Vector3 playerPosition;
        public string canvasName;
        public string shipName;

        public SaveObject(string n, float h, Vector3 pp, string c, string s)
        {
            name = n;
            health = h;
            playerPosition = pp;
            canvasName = c;
            shipName = s;
        }

        public SaveObject()
        {

        }
    }

    public void Save(SaveObject save)
    {

        mobilePath = Application.persistentDataPath;

        string json = JsonUtility.ToJson(save);

        try
        {
            string actualFinalPath = Path.Combine(mobilePath + "/" + save.name + ".json");
            File.WriteAllText(actualFinalPath, json);
            Debug.Log("SAVING SUCCESFUL!");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }



        /*        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                PlayerHealthManager playerHealthManager = playerObject.GetComponent<PlayerHealthManager>();

                string fileName = "saveData";

                string tempPath = Path.Combine(Application.persistentDataPath, "data");
                tempPath = Path.Combine(tempPath, fileName + ".txt");

                Vector3 getPlayerPosition = playerObject.transform.position;
                float getPlayerHealth = playerHealthManager.getPlayerHealth();
                string getCanvasName = playerHealthManager.shipCanvas;
                string getShipName = playerHealthManager.shipName;

                string json = JsonUtility.ToJson(save, true);

        *//*        health = getPlayerHealth,
                    playerPosition = getPlayerPosition,
                    canvasName = getCanvasName,
                    shipName = getShipName,*//*

                if (!Directory.Exists(Path.GetDirectoryName(tempPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
                }

                try
                {
                    File.WriteAllText(tempPath, json);
                }
                catch(Exception e)
                {

                }*/


    }

    public void saveObject()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerHealthManager playerHealthManager = playerObject.GetComponent<PlayerHealthManager>();

        Vector3 getPlayerPosition = playerObject.transform.position;
        float getPlayerHealth = playerHealthManager.getPlayerHealth();
        Debug.Log("PLAYER HEALTH BEFORE SAVE: " + getPlayerHealth);
        string getCanvasName = playerHealthManager.shipCanvas;
        string getShipName = playerHealthManager.shipName;

        SaveObject save = new SaveObject("saveData", getPlayerHealth, getPlayerPosition, getCanvasName, getShipName);

        Save(save);
    }

    public SaveObject LoadGameFile(string name)
    {

        mobilePath = Application.persistentDataPath;
        SaveObject save = new SaveObject();
        string json = File.ReadAllText(mobilePath + "/" + name + ".json");

        JsonUtility.FromJsonOverwrite(json, save);

        return save;

/*        string fileName = "saveData";

        string tempPath = Path.Combine(Application.persistentDataPath, "data");
        tempPath = Path.Combine(tempPath, fileName + ".txt");


        if(!Directory.Exists(Path.GetDirectoryName(tempPath)))
        {
            return;
        }
        if(!File.Exists(tempPath))
        {
            return;
        }

        try
        {
            string saveString = File.ReadAllText(tempPath);
            Debug.Log("Loaded file: " + saveString);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            ShipSelectionToSpawn.shipName = saveObject.shipName;
            ShipSelectionToSpawn.shipHealth = saveObject.health;
            ShipSelectionToSpawn.shipPosition = saveObject.playerPosition;
            ShipSelectionToSpawn.shipCanvas = saveObject.canvasName;

        }
        catch (Exception e)
        {

        }*/
    }

    public SaveObject LoadFromResources(string name)
    {
        mobilePath = "JSONFiles/";
        SaveObject saveObject = new SaveObject();
        mobilePath = mobilePath + name + ".json";

        if(!File.Exists(mobilePath))
        {
            return null;
        }

        string newPath = mobilePath.Replace(".json", "");
        TextAsset ta = Resources.Load<TextAsset>(newPath);
        string json = ta.text;
        JsonUtility.FromJsonOverwrite(json, saveObject);

        return saveObject;
    }

    public void Loadk()
    {
        SaveObject saveObject = LoadFromResources("saveData");
    }

}
