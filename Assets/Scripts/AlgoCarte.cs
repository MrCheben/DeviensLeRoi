﻿using JetBrains.Annotations;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static SaveAndLoad;
using System.Collections.Generic;

public class AlgoCarte : MonoBehaviour   
{
    public int NbCarteTirer;
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
        NbCarteTirer++;
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
            if (item.typeCarte != "Dîme")
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

    // Fonction test si toutes les cartes sont utilis�es
    public void checkIfAllUsed(int typeRange)
    {
        bool isAllUsed = true;

        foreach (var item in players.player[typeRange].texte)
        {
            if (!item.used)
            {
                isAllUsed = false;
            }
        }

        // Si toutes les cartes used alors on remet � false
        if (isAllUsed)
        {
            foreach (var item in players.player[typeRange].texte)
            {
                item.used = false;
            }
        }

    }


    public void checkCarte()
    {
        int typeRange = Random.Range(0, players.player.Length - 1);
        int texteRange = Random.Range(0, players.player[typeRange].texte.Length);
        int suiteRange = Random.Range(0, players.player[typeRange].texte[texteRange].suite.Length);
        int choixRange = Random.Range(0, players.player[typeRange].texte[texteRange].suitechoix.Length);
        int nbPlayer = players.player[typeRange].nbJoueur;

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
                    GetComponent<AlgoPerso>().TirerPlayer(nbPlayer);

                    List<string> listplayer = GetComponent<AlgoPerso>().ListPlayerGame;

                    string txt = players.player[typeRange].texte[texteRange].texteCarte;

                    if (nbPlayer > 0)
                    {
                        for (int i = 0; i < listplayer.Count; i++)
                        {
                            texteCarte.text = txt.Replace("J" + (i+1), listplayer[i]);
                            txt = texteCarte.text;
                        }
                    }
                    else
                    {
                        texteCarte.text = players.player[typeRange].texte[texteRange].texteCarte;
                    }
                    
                    players.player[typeRange].used = true;
                    players.player[typeRange].texte[texteRange].used = true;
                    tourCheckpoint++;
                    checkIfAllUsed(typeRange);
                    if (players.player[typeRange].texte[texteRange].suite.Length > 0)
                    {
                        string txtSuite = players.player[typeRange].texte[texteRange].suite[suiteRange];

                        if (nbPlayer > 0)
                        {
                            for (int i = 0; i < listplayer.Count; i++)
                            {
                                suiteTexte = txtSuite.Replace("J" + (i + 1), listplayer[i]);
                                txtSuite = suiteTexte;
                            }
                        }
                        else
                        {
                            suiteTexte = players.player[typeRange].texte[texteRange].suite[suiteRange];
                        }


                        //DETRUIRE players.player[typeRange].texte[texteRange]
                    }
                    else if (players.player[typeRange].texte[texteRange].choix.Length > 0)
                    {
                        btnChoix1.SetActive(true);
                        btnChoix2.SetActive(true);
                        btnSuivant.SetActive(false);
                        textChoix1.text = players.player[typeRange].texte[texteRange].choix[0];
                        textChoix2.text = players.player[typeRange].texte[texteRange].choix[1];                        

                        string txtChoix = players.player[typeRange].texte[texteRange].suitechoix[choixRange];

                        if (nbPlayer > 0)
                        {
                            for (int i = 0; i < listplayer.Count; i++)
                            {
                                suiteChoix = txtChoix.Replace("J" + (i + 1), listplayer[i]);
                                txtChoix = suiteChoix;
                            }
                        }
                        else
                        {
                            suiteChoix = players.player[typeRange].texte[texteRange].suitechoix[choixRange];
                        }

                        //DETRUIRE players.player[typeRange].texte[texteRange]
                    }
                    else
                    {
                        //DETRUIRE players.player[typeRange].texte[texteRange]
                        //players.player.Remove()
                    }

                }
                else {
                    //Solution temporaire bug Aprés reset carte deja utilisé 
                    randomCarte();
                }
            }
        }
        else
        {
            int countJ=1;
            string storeHealtJ="";
            typeCarte.text = players.player[^1].typeCarte;
            GetComponent<AlgoPerso>().TirerPlayer(0);
            //Function 
            //
            foreach (var item in GetComponent<GlobalSystem>().listHealthBar)
            {
                if (item.text != "0")
                {
                    
                    if (storeHealtJ != "")
                    {
                        if(storeHealtJ == item.text)
                        {
                            countJ++;
                        }
                    }
                    else
                    {
                        storeHealtJ = item.text;
                    }
                }
                else
                {
                    countJ++;
                }
                
            }
            if (countJ== GetComponent<GlobalSystem>().listHealthBar.Count)
            {
                texteCarte.text = players.player[^1].texte[0].texteCarte;
            }
            else
            {
                texteCarte.text = players.player[^1].texte[1].texteCarte;
            }

            
            tourCheckpoint = 0;
        }  
    }
}