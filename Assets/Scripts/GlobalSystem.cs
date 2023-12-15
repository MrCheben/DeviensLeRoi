using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GlobalSystem : MonoBehaviour
{

    public List<InputField> listInputField;
    public List<string> listPlayer;
    public List<int> playerPlateauPosition;
    public int currentPlayer;

    public GameObject CanvasDebut;
    public GameObject CanvasGame;
    public GameObject CanvasEnd;
    public GameObject CanvasCard;
    //public GameObject Test;

    public Text textGagnant;
    //public Text textJoueurActif;

    // Start is called before the first frame update
    void Start()
    {
        CanvasDebut.SetActive(false);
        CanvasGame.SetActive(true);
        CanvasEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }


    public void CatchPlayerName() {

        for (int i = 0; i < listInputField.Count; i++)
        {
            if (listInputField[i].text == "")
            {

            }
            else {
                listPlayer.Add(listInputField[i].text);
                playerPlateauPosition.Add(0);
            }

        }
        currentPlayer = 0;
        changeCanvas("CanvasGame");
        CanvasDebut.SetActive(false);
        CanvasGame.SetActive(true);
        //Turn();
    }

    public int lanceDe()
    {
        var randomDe = Random.Range(1, 7); 
        playerPlateauPosition[currentPlayer] +=randomDe;
        if (playerPlateauPosition[currentPlayer] >= 22) {
            FinDeGame(currentPlayer);
        }
        return randomDe;

    }

/*
    public void changeTurn()
    {
        changePlayerTurn();
        btnSuivant.SetActive(false);
        Turn();
    }
*/
/*
    public int changePlayerTurn() {
        if (currentPlayer == listPlayer.Count-1)
        {
            currentPlayer = 0;
            
        }
        else {
            currentPlayer++;
        }
        textJoueurActif.text = listPlayer[currentPlayer];
        return currentPlayer;
       
    }
*/
/*
    public void Turn()
    {
        print("D� : "+lanceDe());
        // Sur quelle type de case il tombe
        GameObject.Find("DrawCard").GetComponent<CardsDraw>().drawCard(playerPlateauPosition[currentPlayer]);
        //btnSuivant.SetActive(true);


    }
*/
    public void FinDeGame(int gagant ) {
        changeCanvas("CanvasEndGame");
        textGagnant.text="GAGNANT "+ listPlayer[gagant];
        


    }


    public void Rejouer()
    {
        SceneManager.LoadScene(0);
    }

    public void changeCanvas(string etat)
    {
        if (etat == "Debut")
        {
            CanvasDebut.SetActive(true);
            CanvasGame.SetActive(false);
            CanvasEnd.SetActive(false);
        }
        else if (etat == "Game")
        {
            CanvasDebut.SetActive(false);
            CanvasGame.SetActive(true);
            CanvasEnd.SetActive(false);
            //textJoueurActif.text =listPlayer[currentPlayer];
        }
        else if (etat == "End")
        {
            CanvasDebut.SetActive(false);
            CanvasGame.SetActive(false);
            CanvasEnd.SetActive(true);
            CanvasCard.SetActive(false);
        }
    }

}
