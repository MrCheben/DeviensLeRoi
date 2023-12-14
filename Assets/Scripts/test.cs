using JetBrains.Annotations;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static SaveAndLoad;

public class test : MonoBehaviour   
{

    public TextAsset jsonData;
    public PlayerList players = new PlayerList();

    public int tourCheckpoint = 0;
    public int typeUse = 0;
    public int texteUse = 0;
    public string suiteTexte = "";


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
            if (suiteTexte != "")
            {
                Debug.Log(suiteTexte);
                suiteTexte = "";
            }
            else
            {
                randomCarte();
            }
        }
    }

    public void randomCarte()
    {
        foreach (var item in players.player)
        {
            if (item.typeCarte != "checkpoint")
            {
                if (item.used == true)
                {
                    typeUse++;
                    if (typeUse == players.player.Length - 1)
                    {
                        for (int i = 0; i < players.player.Length - 1; i++)
                        {
                            players.player[i].used = false;
                        }
                        tirageCarte();
                        break;
                    }
                }
                else
                {
                    typeUse = 0;
                    tirageCarte();
                    break;
                }
            }
        }
    }

    public void tirageCarte()
    {
        int typeRange = Random.Range(0, players.player.Length - 1);
        int texteRange = Random.Range(0, players.player[typeRange].texte.Length);
        int suiteRange = Random.Range(0, players.player[typeRange].texte[texteRange].suite.Length);

        if (tourCheckpoint < 3)
        {
            if (players.player[typeRange].used == true)
            {                
                randomCarte();
            }
            else
            {
                if (players.player[typeRange].texte[texteRange].used == false)
                {
                    Debug.Log("Not Used");
                    Debug.Log(players.player[typeRange].typeCarte);
                    Debug.Log(players.player[typeRange].texte[texteRange].texteCarte);
                    players.player[typeRange].used = true;
                    players.player[typeRange].texte[texteRange].used = true;
                    tourCheckpoint++;
                    if (players.player[typeRange].texte[texteRange].suite.Length > 0)
                    {                        
                        suiteTexte = players.player[typeRange].texte[texteRange].suite[suiteRange];
                    }
                }
            }
        }
        else
        {
            Debug.Log(players.player[^1].typeCarte);
            Debug.Log(players.player[^1].texte[0].texteCarte);
            tourCheckpoint = 0;
        }
    }


}
