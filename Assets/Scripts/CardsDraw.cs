using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardsDraw : MonoBehaviour
{

    //public string[] TypeCard = new string[] { "", "Bonus", "Malus", "Duel", "General", "Choix", "DebutFin" };
    public string[] TypeCard = new string[] {};
    public string[] BonusCard = new string[] { "Avances de � cases.", "Donne � gorg�es.", "Ta place est �chang�e avec �.", "Tes prochaines gorg�es sont divis�es par 2." };
    public string[] MalusCard = new string[] { "Recules de � cases.", "Prends � gorg�es.", "Ta place est �chang�e avec �.", "Tes prochaines gorg�es sont doubl�es." };
    public string[] DuelCard = new string[] { "Shifumi avec �, 2 gorg�es au perdant.", "Devine ce que je vois, le gagnant donne 2 gorg�es." };
    public string[] GeneralCard = new string[] { "Dans ma grand-m�re il y a ... (Le perdant bois 2 gorg�es)", "Jeu des rimes, choisis un mot et c'est parti, le perdant bois 2 gorg�es.", "Main noire, main blanche, les perdants boivent 2 gorg�es." };
    public string[] ChoixCard = new string[] { "Prends 5 gorg�es ou recul de 3 cases.", "Avances de 2 cases ou donnes 2 gorg�es.", "Fais reculer � de 3 cases ou avances de 2 cases." };
    public string nomCarte;

    public Sprite[] listImgCard;

    public Text cardTitle;
    public Text cardText;
    //public RawImage cardImage;
    private GlobalSystem globalSystem;
    void Start()
    {
        globalSystem = GameObject.Find("MainGameplay").GetComponent<GlobalSystem>();


    }


/*
    public void drawCard(int nbCase) { 
        Plateau PlateauScript = GameObject.Find("PlateauGameobject").GetComponent<Plateau>();
        print(PlateauScript.returnTypeCase(nbCase));
        getCard(TypeCard[PlateauScript.returnTypeCase(nbCase)]);
    }
*/
    public void getCard(string cardType)
    {
        string txtCard = "";
        //int nbOfCards = 0;
       // int aleatCard = 0;

        if (cardType == "Bonus") {

            txtCard = BonusCard[Random.Range(0, BonusCard.Length)];
        }
        else if (cardType == "Malus") {
            txtCard = MalusCard[Random.Range(0, MalusCard.Length)];
        }
        else if (cardType == "Duel")
        {
            txtCard = DuelCard[Random.Range(0, DuelCard.Length)];
        }
        else if (cardType == "General")
        {
            txtCard = GeneralCard[Random.Range(0, GeneralCard.Length)];
        }
        else if (cardType == "Choix")
        {
            txtCard = ChoixCard[Random.Range(0, ChoixCard.Length)];
        }


        txtCard=txtCard.Replace("�", Random.Range(1, 4).ToString());
        txtCard=txtCard.Replace("�", globalSystem.listPlayer[Random.Range(0, globalSystem.listPlayer.Count)]);

        cardTitle.text = cardType;
        cardText.text = txtCard;
/*
        if (cardTitle.text == "Bonus")
        {
            cardImage.texture = listImgCard[0].texture;
        }else if (cardTitle.text == "Malus")
        {
            cardImage.texture = listImgCard[1].texture;
        }
        else if (cardTitle.text == "Duel")
        {
            cardImage.texture = listImgCard[2].texture;
        }
        else if (cardTitle.text == "General")
        {
            cardImage.texture = listImgCard[3].texture;
        }
        else if (cardTitle.text == "Choix")
        {
            cardImage.texture = listImgCard[4].texture;
        }
*/





        /*
        switch (cardType)
        {
            case "Bonus":
                nbOfCards = bonusCard.Length;
                if (nbOfCards != 0)
                {
                    aleatCard = Random.Range(0, nbOfCards);
                    txtCard = bonusCard.GetValue(aleatCard).ToString();
                }
                break;
            case "Malus":
                nbOfCards = malusCard.Length;
                if (nbOfCards != 0)
                {
                    aleatCard = Random.Range(0, nbOfCards);
                    txtCard = malusCard.GetValue(aleatCard).ToString();
                }
                break;
            case "Duel":
                nbOfCards = duelCard.Length;
                if (nbOfCards != 0)
                {
                    aleatCard = Random.Range(0, nbOfCards);
                    txtCard = duelCard.GetValue(aleatCard).ToString();
                }
                break;
            case "General":
                nbOfCards = generalCard.Length;
                if (nbOfCards != 0)
                {
                    aleatCard = Random.Range(0, nbOfCards);
                    txtCard = generalCard.GetValue(aleatCard).ToString();
                }
                break;
            case "Choix":
                nbOfCards = choixCard.Length;
                if (nbOfCards != 0)
                {
                    aleatCard = Random.Range(0, nbOfCards);
                    txtCard = choixCard.GetValue(aleatCard).ToString();
                }
                break;

            case "SF":
                break;
        
            default:
                break;
        }

        Debug.Log(txtCard);
        return txtCard;*/

    }

    void Update()
    {
        
    }
}
