using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardsDraw : MonoBehaviour
{

    public string[] TypeCard = new string[] { "Duel", "Maillon Faible", "Victime", "Dilemme", "Stratégie", "Immunité"};
    private string[] CarteDuel = new string[] { "J1 et J2 sont en duel vous devrez mimer une arme imaginaire le plus vite possible le perdant perd 2 vie (l'arme au prochain slide)", "J1 et J2 font un massu, bouclier, arc le loooseeerrr perd 2 vie."};
    private string[] CarteMFaible = new string[] { "J1 contre le monde, vous devrez à tour de role dire une marque de voiture", "J1 contre J2 et J3, J1 à fait de la merde il boit ou lèche le cucu"};
    private string[] CarteVictime = new string[] { "J1 trouve J2 enterré la tete dans le sol, J1 tente de lui mettre un coup de pied dans la tête ou lui faire caca sur la tête"};
    private string[] CarteDilemme = new string[] { "J1 tu te bats contre J2 dans une maison abandoné , il y a un levier l'actionne tu ? 2 choix dispo"};
    private string[] CarteStratégie = new string[] { "chacun tire 2 balle a tour de role vous pouvez choisir plusieurs cible , le joueur touché ne peut plus tirer -> Joueur X Commence + tour horaire (1 balle une vie)" };
    private string[] CarteImmunité = new string[] { "J1 obtient une armure pour la prochaine fois qu'il perd de la vie", "J1 ramasse un bouclier et sera immuniser à la prochaine carte seulement" };
    private string[] CarteCheckpoint= new string[] { "J1 à le plus de vie et prend donc 3 gorgées, suivi de J2 qui prend 2 gorgés et tous le reste prend 1 gorgée", "Tous le monde est au même niveau, j'offre une tournée générale" };
    private string[] CarteVictimeSuite = new string[] { "coup de pied prend de l'élan mais se loupe, lorsqu'il se penche il trèbuche et s'empale sur son épée (perd vie), random même si on tombe plusieurs fois sur la même carte victime"};
    private string[] CarteDilemmeSuite = new string[] { "Le résultat est random même si on tombe plusieurs fois sur le même dilemme"};
    public List<string> listCard;
    public List<string> ListCardGame;
    public int tourCheckpoint=0;

    public Sprite[] listImgCard;

    public Text cardTitle;
    public Text cardText;
    public RawImage cardImage;
    public GameObject CanvasCard;
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

    
    public void selectCard()
    {
        CanvasCard.SetActive(true);
        if (tourCheckpoint < 3){
            string cardType = TypeCard[Random.Range (0, TypeCard.Length)]; 
            tourCheckpoint ++;
            Debug.Log("Carte de type : " + cardType);
            getCard(cardType);
            Debug.Log("Tour CP : " + tourCheckpoint);
            }
        else
            {
            Debug.Log("Carte de type Checkpoint");
            string cardType = "Checkpoint";            
            getCard(cardType);
            tourCheckpoint = 0;
            }
    }


    public void getCard(string cardType)
    {
        string txtCard = "";

        if (cardType == "Duel") {
            txtCard = CarteDuel[Random.Range(0, CarteDuel.Length)];
        }
        else if (cardType == "Maillon Faible") {
            txtCard = CarteMFaible[Random.Range(0, CarteMFaible.Length)];
        }
        else if (cardType == "Victime")
        {
            txtCard = CarteVictime[Random.Range(0, CarteVictime.Length)];
        }
        else if (cardType == "Dilemme")
        {
            txtCard = CarteDilemme[Random.Range(0, CarteDilemme.Length)];
        }
        else if (cardType == "Stratégie")
        {
            txtCard = CarteStratégie[Random.Range(0, CarteStratégie.Length)];
        }
        else if (cardType == "Immunité")
        {
            txtCard = CarteImmunité[Random.Range(0, CarteImmunité.Length)];
        }
        else if (cardType == "Checkpoint")
        {
            txtCard = CarteCheckpoint[Random.Range(0, CarteCheckpoint.Length)];
        }

        Debug.Log(txtCard);

        //txtCard=txtCard.Replace("J1", "Yes")]);
        cardTitle.text = cardType;
        cardText.text = txtCard;

        if (cardType == "Duel")
        {
            cardImage.texture = listImgCard[0].texture;
        }else if (cardType == "Maillon Faible")
        {
            cardImage.texture = listImgCard[1].texture;
        }
        else if (cardType == "Victime")
        {
            cardImage.texture = listImgCard[2].texture;
        }
        else if (cardType == "Dilemme")
        {
            cardImage.texture = listImgCard[3].texture;
        }
        else if (cardType == "Stratégie")
        {
            cardImage.texture = listImgCard[4].texture;
        }
        else if (cardType == "Immunité")
        {
            cardImage.texture = listImgCard[5].texture;
        }
        else if (cardType == "Checkpoint")
        {
            cardImage.texture = listImgCard[6].texture;
        }      
    }

      void Update(){

    }
}



  


