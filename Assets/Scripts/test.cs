using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static SaveAndLoad;

public class test : MonoBehaviour   
{

    public TextAsset jsonData;
    public PlayerList players = new PlayerList();

    public int tourCheckpoint = 0;


    [System.Serializable]
    public class Player
    {
        public bool used;
        public string typeCarte;
        public Texte[] texte;
    }

    [System.Serializable]
    public class Texte
    {
        public bool used;
        public string texteCarte;
        public string[] suite;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }


    // Start is called before the first frame update
    void Start()
    {
        players = JsonUtility.FromJson<PlayerList>(jsonData.text);
    }



    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            tirageCarte();
            /*int test = Random.Range(0, players.player.Length);
            int prout = Random.Range(0, players.player[0].texte[0].suite.Length);
            Debug.Log(players.player[test].texte[0].suite.Length);
            Debug.Log(players.player[test].typeCarte);
            Debug.Log(players.player[test].texte[0].texteCarte);
            Debug.Log(players.player[test].texte[0].suite[prout]);*/
        }
    }


    public void tirageCarte()
    {
        int texteRange = Random.Range(0, players.player[0].texte[0].suite.Length);
        int typeRange = Random.Range(0, players.player.Length-1);
        //Debug.Log(players.player[typeRange].typeCarte);
        //Debug.Log(players.player[typeRange].texte[0].texteCarte);
        if (tourCheckpoint < 3)
        {
            if (players.player[typeRange].used == true)
            {
                tirageCarte();
            }
            else
            {
                Debug.Log(players.player[typeRange].typeCarte);
                Debug.Log(players.player[typeRange].texte[0].texteCarte);
                players.player[typeRange].used = true;
                tourCheckpoint++;
            }
        }
        else
        {
            Debug.Log(players.player[3].typeCarte);
            Debug.Log(players.player[3].texte[0].texteCarte);
            tourCheckpoint = 0;
        }
    }


}
