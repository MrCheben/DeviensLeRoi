using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoPerso : MonoBehaviour
{

    public List<string> listPlayer;
    public List<int> nbPlayed;
    public List<string> transitionListPlayer;
    public List<string> ListPlayerGame;
    public int NbJ=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ListPlayerGame.Clear();
            NbJ = Random.Range(1,5);
            addToCurrentList(0);
            
        }
    }


    public void addToCurrentList(int scoreP)
    {
        Debug.Log("Jeu a " + NbJ + " Joueurs");
        //Ajout a la liste de transtion
        var index = 0;
        foreach (var item in nbPlayed)
        {
            if (item == scoreP)
            {
                transitionListPlayer.Add(listPlayer[index].ToString());
            }
            index++;
        }
        selectPlayer(NbJ);
    }

    public void selectPlayer(int nbPlayer)
    {
        //Check if nb player in current list >= nbPlayer
        if (transitionListPlayer.Count >= nbPlayer)
        {
            //Shuffle l'array
            transitionListPlayer = shuffleGOList(transitionListPlayer);
            for (int i = 0; i < nbPlayer; i++)
            {
                ListPlayerGame.Add(transitionListPlayer[i].ToString());
                nbPlayed[listPlayer.FindIndex(a => a.Contains(transitionListPlayer[i].ToString()))] = 1;

            }
            transitionListPlayer.Clear();
            //ResetScoreP();
        }
        else
        {
            transitionListPlayer = shuffleGOList(transitionListPlayer);
            for (int i = 0; i < transitionListPlayer.Count; i++)
            {
                ListPlayerGame.Add(transitionListPlayer[i].ToString());
                //nbPlayed[listPlayer.FindIndex(a => a.Contains(transitionListPlayer[i].ToString()))] = 1;

            }
            transitionListPlayer.Clear();

            // if pas assez de joueur on va chercher les autres jouurs qui sont deja 1 
            addToCurrentList(1);
            //On Shuffle quand même l'array
            transitionListPlayer = shuffleGOList(transitionListPlayer);
            for (int i = 0; i < nbPlayer - ListPlayerGame.Count; i++)
            {
                ListPlayerGame.Add(transitionListPlayer[i].ToString());
                nbPlayed[listPlayer.FindIndex(a => a.Contains(transitionListPlayer[i].ToString()))] = 1;
            }
            transitionListPlayer.Clear();
            //ResetScoreP();

        }

    }

    private void ResetScoreP()
    {
        for (int i = 0; i < ListPlayerGame.Count; i++)
        {
            if (nbPlayed[listPlayer.FindIndex(a => a.Contains(ListPlayerGame[i].ToString()))] == 1)
            {
                nbPlayed[listPlayer.FindIndex(a => a.Contains(ListPlayerGame[i].ToString()))] = 0;
            }
            else
            {
                nbPlayed[listPlayer.FindIndex(a => a.Contains(ListPlayerGame[i].ToString()))] = 1;
            }


        }
    }


    private List<string> shuffleGOList(List<string> inputList)
    {    //take any list of GameObjects and return it with Fischer-Yates shuffle
        int i = 0;
        int t = inputList.Count;
        int r = 0;
        string p = null;
        List<string> tempList = new List<string>();
        tempList.AddRange(inputList);

        while (i < t)
        {
            r = Random.Range(i, tempList.Count);
            p = tempList[i];
            tempList[i] = tempList[r];
            tempList[r] = p;
            i++;
        }

        return tempList;
    }


}
