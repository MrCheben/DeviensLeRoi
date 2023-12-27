using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayer : MonoBehaviour
{

    public GameObject CanvasPlayer;
    public GameObject addCustomPlayer;
    public TMP_InputField PlayerName;    
    public Button PrefabPlayer;
    public Button PlayerCustom;
    public List<GameObject> PlayerList;
    public List<Transform> PlayerNameSpawn;
    public TMP_Text ErrorPlayerText;
    public int NbJoueur;

    // Start is called before the first frame update
    void Start()
    {
        addCustomPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayer()
    {

        if (NbJoueur < 8)
        {
            if (PlayerName.text != "")
            {
                Button Player = Instantiate(PrefabPlayer);
                Player.name ="PrefabPlayer"+ NbJoueur;
                Player.transform.SetParent(CanvasPlayer.transform, false);
                Player.transform.position = PlayerNameSpawn[NbJoueur].position;
                Player.GetComponentInChildren<TMP_Text>().text = PlayerName.text;
                Player.onClick.AddListener(delegate { customName(Player, NbJoueur + 1); });            
                Button[] arrayChildrenBtn = Player.GetComponentsInChildren<Button>();
                Button DeletePlayer = arrayChildrenBtn[1];
                DeletePlayer.onClick.AddListener(delegate { removePlayer(Player.gameObject); });


                PlayerList.Add(Player.gameObject);
                NbJoueur++;
                PlayerName.text = "";

            }
            else
            {
                Debug.Log("Nom vide");
            }
        }
        else
        {
            ErrorPlayerText.text = "8 Joueurs maximums";
            ErrorPlayerText.gameObject.GetComponent<Animator>().Play("FadeOut");
            PlayerName.text = "";
        }
    }

    public void customName(Button name,int numberPlacement)
    {
        Debug.Log(numberPlacement);
        addCustomPlayer.SetActive(true);
        PlayerName.text = name.GetComponentInChildren<TMP_Text>().text;
        PlayerCustom = name;
    }

    public void addCustomName()
    {
        addCustomPlayer.SetActive(false);
        PlayerCustom.GetComponentInChildren<TMP_Text>().text = PlayerName.text;
        if (PlayerName.text == "")
        {
            removePlayer(PlayerCustom.gameObject);
        }
        else
        {
            PlayerName.text = "";
        }
    }


    public void removePlayer(GameObject playerR)
    {
        int indexP=PlayerList.IndexOf(playerR);
        for (int i = indexP+1; i < PlayerList.Count; i++)
        {
            PlayerList[i].transform.position = PlayerNameSpawn[i - 1].position;
        }
        Destroy(playerR);
        PlayerList.Remove(playerR);
        NbJoueur--;
    }
}
