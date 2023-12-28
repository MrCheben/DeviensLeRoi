using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject[] Coeur;
    public Sprite plein;
    public Sprite vide;
    public Text texte;
    public int indexListPlayer;
    public int maxVie = 10;
    public int lastVie = 10;
    public int playerDead;

    public void Trigger(int nbVie)
    {
        if (Coeur[nbVie - 1].GetComponent<Image>().sprite == plein && nbVie == lastVie)
        {          
            for (int u = nbVie; u < maxVie; u++)
            {
                Coeur[u].GetComponent<Image>().sprite = vide;
            }
            nbVie--;

            Coeur[nbVie].GetComponent<Image>().sprite = vide;
            lastVie = lastVie - 1;   

        }
        else 
        {
            for (int y = nbVie; y < maxVie; y++)
            {
                Coeur[y].GetComponent<Image>().sprite = vide;
            }
            for (int i = 0; i < nbVie; i++)
            {
                Coeur[i].GetComponent<Image>().sprite = plein;
            }
            lastVie = nbVie;            
        }
        texte.text = nbVie.ToString();
        if(nbVie == 0)
        {
            GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().nbPlayed[indexListPlayer] = -1;
        }

        if (GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().nbPlayed[indexListPlayer] == -1 && nbVie > 0)
        {
            GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().nbPlayed[indexListPlayer] = 0;
            GameObject.Find("MainGameplay").GetComponent<GlobalSystem>().playerDead--;
            GameObject.Find("CanvasVie").GetComponentInChildren<Button>().onClick.AddListener(() => GameObject.Find("MainGameplay").GetComponent<GlobalSystem>().changeCanvas("Game"));
        }

        if (GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().nbPlayed[indexListPlayer] == -1)
        {
            GameObject.Find("MainGameplay").GetComponent<GlobalSystem>().playerDead++;
            if (GameObject.Find("MainGameplay").GetComponent<GlobalSystem>().playerDead == GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().listPlayer.Count - 1)
            {
                for (int i = 0; i < GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().listPlayer.Count; i++)
                {
                    if(GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().nbPlayed[i] != -1)
                    {
                        GameObject.Find("MainGameplay").GetComponent<GlobalSystem>().playerWinner = GameObject.Find("MainGameplay").GetComponent<AlgoPerso>().listPlayer[i];                      
                        GameObject.Find("CanvasVie").GetComponentInChildren<Button>().onClick.AddListener(() => GameObject.Find("MainGameplay").GetComponent<GlobalSystem>().changeCanvas("End"));
                    }                   
                }                
            }
        }        
    }    
}
