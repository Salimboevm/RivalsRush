//Author: Mokhirbek Salimboev
//Last Edit: 08/02/2021
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    
    

    #region Singleton
    private static GameUI instance;
    public static GameUI Instance { get => instance; }
    public int TempCoins { get => tempCoins; set => tempCoins = value; }
    public Text UserId { get => userId; set => userId = value; }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }
    #endregion
    private int tempCoins=0;
    #region Variables
    //text variables for gameplay changing
    [SerializeField]
    private Text scoreText;//realtime score show text
    [SerializeField]
    private Text rankText;//real time rank show text
    [SerializeField]
    private Text coinsText;//call when coins are gained/lost
    [SerializeField]
    private Text powerupText;//real time current power up name text
    [SerializeField]
    private Text nameOfObj;//name of item
    [SerializeField]
    private Image imageOfItem;//self expl, shows image of current item
    [SerializeField]
    private Text winnerCoinsText;//text object, to show total amount of coins in the end
    [SerializeField]
    private Text userId;
    #endregion

    #region Menu variables
    //gameobject variables to make pause/lost/won screens
    [SerializeField]
    private GameObject pauseMenu;//panel for pause menu
    [SerializeField]
    private GameObject lostMenu;//panel for lost menu
    [SerializeField]
    private GameObject wonMenu;//panel for won menu

    #endregion

    #region Text Functions
    /// <summary>
    /// call when score changed
    /// gets score text value 
    /// returns value to screen
    /// </summary>
    /// <param name="scoreText"></param>
    public void LapText(short score)
    {
        this.scoreText.text = score.ToString();
    }
    /// <summary>
    /// call when player rank changed
    /// gets rank text value
    /// returns value to screen
    /// </summary>
    /// <param name="rankText"></param>
    public void RankText(Text rankText)
    {
        this.rankText.text = rankText.text;
    }
    /// <summary>
    /// call when coins gained/lost
    /// gets value from player coins 
    /// returns value to the screen
    /// </summary>
    /// <param name="coinsText"></param>
    public void CoinsText(int coinsTextAmount)
    {
        TempCoins += coinsTextAmount;
        coinsText.text = TempCoins.ToString();
    }
    /// <summary>
    /// call when power up found
    /// gets value from player power up 
    /// returns value to the screen
    /// </summary>
    /// <param name="powerupText"></param>
    public void PowerUpText(Text powerupText)
    {
        this.powerupText.text = powerupText.text;
    }
    #endregion

    #region Menu Functions
    /// <summary>
    /// call when player pauses game
    /// </summary>
    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    /// <summary>
    /// call when player is lost
    /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0;
        lostMenu.SetActive(true);
    }
    /// <summary>
    /// call when player wins the game
    /// </summary>
    public void Win()
    {
        wonMenu.SetActive(true);
        winnerCoinsText.text = tempCoins.ToString();        
    }
    /// <summary>
    /// call when player resumes game
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        wonMenu.SetActive(false);
        PhotonNetwork.LeaveRoom(true);
        
        SceneManager.LoadScene(0);
    }
    #endregion
    private void Update()
    {
        coinsText.text = tempCoins.ToString();//updating coins text in each frame
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }    
    }
    /// <summary>
    /// func to update booster ui
    /// text and image 
    /// </summary>
    public void BoostUpdate()
    {
        BoostItemObject tempBoost = FindObjectOfType<BoostItemObject>();//get booster obj 
        nameOfObj.text = tempBoost.NameOfObj;//change name 
        imageOfItem.sprite = tempBoost.ImageOfObj;//change img
    }
}
