using JetBrains.Annotations;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static SaveAndLoad;

public class AlgoCarte : MonoBehaviour   
{

    public TextAsset jsonData;
    public PlayerList players = new PlayerList();
    public GameObject btnChoix1;
    public GameObject btnChoix2;
    public GameObject btnSuivant;
    public TMP_Text typeCarte;
    public TMP_Text texteCarte;
    TMP_Text textChoix1;
    TMP_Text textChoix2;
    public int tourCheckpoint = 0;
    public int typeUse = 0;
    public int texteUse = 0;
    public string suiteTexte = "";
    public string suiteChoix = "";
    public bool gameStarted=false;


    [System.Serializable]
    public class Player
    {
        public bool used;
        public string typeCarte;
        public int nbJoueur;
        public Texte[] texte;
    }

    [System.Serializable]
    public class Texte
    {
        public bool used;
        public string texteCarte;
        public string[] suite;
        public string[] choix;
        public string[] suitechoix;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    void Start()
    {
        players = JsonUtility.FromJson<PlayerList>(jsonData.text);
        btnChoix1.SetActive(false);
        btnChoix2.SetActive(false);
        textChoix1=btnChoix1.GetComponentInChildren<TMP_Text>();
        textChoix2 = btnChoix2.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
    }

    public void tirageCarte()
    {
        if (!gameStarted)
        {
            gameStarted = true;
        }

        if (suiteTexte != "")
        {
            texteCarte.text = suiteTexte;
            suiteTexte = "";
        }
        else
        {
            randomCarte();
        }
    }

    public void choixCarte()
    {
        btnChoix1.SetActive(false);
        btnChoix2.SetActive(false);
        btnSuivant.SetActive(true);
        texteCarte.text = suiteChoix;
        suiteChoix = "";
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
                        checkCarte();
                        break;
                    }
                }
                else
                {
                    typeUse = 0;
                    checkCarte();
                    break;
                }
            }
        }
    }

    public void checkCarte()
    {
        int typeRange = Random.Range(0, players.player.Length - 1);
        int texteRange = Random.Range(0, players.player[typeRange].texte.Length);
        int suiteRange = Random.Range(0, players.player[typeRange].texte[texteRange].suite.Length);
        int choixRange = Random.Range(0, players.player[typeRange].texte[texteRange].suitechoix.Length);
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
                    typeCarte.text = players.player[typeRange].typeCarte;
                    texteCarte.text = players.player[typeRange].texte[texteRange].texteCarte;
                    players.player[typeRange].used = true;
                    players.player[typeRange].texte[texteRange].used = true;
                    tourCheckpoint++;
                    if (players.player[typeRange].texte[texteRange].suite.Length > 0)
                    {                        
                        suiteTexte = players.player[typeRange].texte[texteRange].suite[suiteRange];
                    }
                    if (players.player[typeRange].texte[texteRange].choix.Length > 0)
                    {
                        btnChoix1.SetActive(true);
                        btnChoix2.SetActive(true);
                        btnSuivant.SetActive(false);
                        textChoix1.text = players.player[typeRange].texte[texteRange].choix[0];
                        textChoix2.text = players.player[typeRange].texte[texteRange].choix[1];
                        suiteChoix = players.player[typeRange].texte[texteRange].suitechoix[choixRange];
                    }
                }
            }
        }
        else
        {
            typeCarte.text = players.player[^1].typeCarte;
            texteCarte.text = players.player[^1].texte[0].texteCarte;
            tourCheckpoint = 0;
        }
    }
}