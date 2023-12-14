using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static test;

public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            SaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }

    }

    public Carte paquetCarte = new Carte();

    public void SaveToJson()
    {
        string carteData = JsonUtility.ToJson(paquetCarte);
        string filePath = Application.persistentDataPath + "/CarteData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, carteData);
        Debug.Log("Save OK");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/CarteData.json";
        string carteData = System.IO.File.ReadAllText(filePath);

        paquetCarte = JsonUtility.FromJson<Carte>(carteData);


        Debug.Log("Load OK");
    }


    [System.Serializable]
    public class Carte
    {
        public Types[] types;
    }

    [System.Serializable]

    public class Types
    {
        public bool used;
        public string nomCarte;
        public Texte[] textes;
    }

    [System.Serializable]

    public class Textes
    {
        public bool used;
        public string texteCarte;
        public string[] suite;
    }

}

