using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GlobalSystem : MonoBehaviour
{
    AlgoPerso algoPerso;
    AlgoCarte algoCarte;
    AddPlayer addPlayer;
    public int currentPlayer;
    public GameObject CanvasDebut;
    public GameObject CanvasGame;
    public GameObject CanvasEnd;
    public GameObject CanvasContext;
    public GameObject CanvasVie;
    public TMP_Text ErrorPlayerText;
    public GameObject PrefabHealthBar;
    public Text textGagnant;
    Vector3 OffsetPrefabHealthBar = new Vector3(-600,510,0);    

    // Start is called before the first frame update
    void Start()
    {
        changeCanvas("Debut");
        algoPerso = GetComponent<AlgoPerso>();
        algoCarte = GetComponent<AlgoCarte>();
        addPlayer = GetComponent<AddPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CatchPlayerName() {
        if (addPlayer.PlayerList.Count >= 4)
        {
        for (int i = 0; i < addPlayer.PlayerList.Count; i++)
        {
                algoPerso.listPlayer.Add(addPlayer.PlayerList[i].GetComponentInChildren<TMP_Text>().text);
                algoPerso.nbPlayed.Add(0);
        }
        for (int i = 0; i < algoPerso.nbPlayed.Count; i++)
        {
            GameObject HealthBar = Instantiate(PrefabHealthBar);
            HealthBar.transform.SetParent(CanvasVie.transform, false);
            HealthBar.transform.position= CanvasVie.transform.position + OffsetPrefabHealthBar;
            HealthBar.GetComponent<Text>().text = algoPerso.listPlayer[i];
            OffsetPrefabHealthBar += new Vector3(0, -150,0);
        }
        currentPlayer = 0;
        changeCanvas("Context");
        }
        else
        {
            ErrorPlayerText.text = "4 Joueurs minimuns";
            ErrorPlayerText.gameObject.GetComponent<Animator>().Play("FadeOut");
            //StartCoroutine(DisplayErroMessage());
        }
    }

    IEnumerator DisplayErroMessage()
    {
        yield return new WaitForSeconds(3);
        
    }

    public void changeCanvas(string etat)
    {
        if (etat == "Debut")
        {
            CanvasDebut.SetActive(true);
            CanvasGame.SetActive(false);
            CanvasEnd.SetActive(false);
            CanvasContext.SetActive(false);
            CanvasVie.SetActive(false);
        }
        
        else if (etat == "Context")
        {
            CanvasContext.SetActive(true);
            CanvasDebut.SetActive(false);
            CanvasGame.SetActive(false);
            CanvasEnd.SetActive(false);
            CanvasVie.SetActive(false);
        }
        else if (etat == "Game")
        {
            CanvasDebut.SetActive(false);
            CanvasGame.SetActive(true);
            CanvasEnd.SetActive(false);
            CanvasContext.SetActive(false);
            CanvasVie.SetActive(false);
            if (!algoCarte.gameStarted)
            {
                algoCarte.tirageCarte();
            }
            
        }
        else if (etat == "Vie")
        {
            CanvasDebut.SetActive(false);
            CanvasGame.SetActive(false);
            CanvasEnd.SetActive(false);
            CanvasContext.SetActive(false);
            CanvasVie.SetActive(true);
        }
        
        else if (etat == "End")
        {
            CanvasDebut.SetActive(false);
            CanvasGame.SetActive(false);
            CanvasEnd.SetActive(true);
            CanvasContext.SetActive(false);
            CanvasVie.SetActive(false);
        }
    }

    public void DeathPlayer()
    {
        foreach (var item in transform)
        {
            if (true)
            {
                
            }
        }
    }
}