using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateau : MonoBehaviour
{

    private int[] pattern1 = { 0, 3, 2, 4, 1, 5, 4, 3, 5, 1, 2, 4, 5, 4, 5, 1, 3, 4, 5, 4, 5, 2, 0 };
    private int[] pattern2 = { 0, 5, 4, 1, 2, 4, 5, 3, 5, 3, 4, 1, 5, 2, 4, 3, 5, 1, 5, 4, 2, 4, 0 };
    private int[] pattern3 = { 0, 2, 1, 2, 5, 4, 3, 5, 3, 5, 2, 4, 5, 1, 4, 5, 4, 3, 4, 5, 1, 4, 0 };
    public int[] choosenPattern;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePattern();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int returnTypeCase(int nbCase)
    {
        var IdTypeCase=choosenPattern[nbCase];
        return IdTypeCase;
        /*if (nbCase == 1)
        {
            nameTypeCase = "Bonus";
        }
        else if (nbCase == 2)
        {
            nameTypeCase = "Malus";
        }
        else if (nbCase == 3)
        {
            nameTypeCase = "Duel";
        }
        else if (nbCase == 4)
        {
            nameTypeCase = "General";
        }
        else if (nbCase == 5)
        {
            nameTypeCase = "Choix";
        }*/
    }

    private void GeneratePattern()
    {
        var randomPattern = Random.Range(1, 4);

        if (randomPattern == 1)
        {
            choosenPattern = pattern1;
        }
        else if (randomPattern == 2)
        {
            choosenPattern = pattern2;
        }
        else if (randomPattern == 3)
        {
            choosenPattern = pattern3;
        }

        print("Plateau Choisit : " + randomPattern);

        /* foreach (var item in choosenPattern)
         {

         }*/

    }

}
