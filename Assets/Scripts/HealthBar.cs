using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject[] Coeur;
    public Sprite plein;
    public Sprite vide;
    public Text texte;

    public int maxVie = 10;
    public int lastVie;

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
            lastVie = 0;            
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
    }    
}
