using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//EVENTUALLY MOVE THE GAMEMANAGER OBJECT AND SCRIPT INTO THE LOADING SCREEN
//this will be where you choose New Game or Continue, all variables will be initialized or loaded there
//this way the gamemanager object will stay loaded from that point on

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerTopDown player;
    //public weapon weapon...

    // Logic
    //preferred player skin
    public int coins;
    public int experience;

    //save states
    public void SaveState()
    {
        string s = "";

        s += "0" + "|"; //player skin
        s += coins.ToString() + "|"; //players money
        s += experience.ToString() + "|"; //players exp


        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {

        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);

    }

}
