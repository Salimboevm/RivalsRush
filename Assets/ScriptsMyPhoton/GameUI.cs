//Author: Mokhirbek Salimboev
//Last Edit: 08/02/2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    #region Texts Variables
    //text variables for gameplay changing
    [SerializeField]
    private Text scoreText;//realtime score show text
    [SerializeField]
    private Text rankText;//real time rank show text
    [SerializeField]
    private Text coinsText;//call when coins are gained/lost
    [SerializeField]
    private Text powerupText;//real time current power up name text
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
    public void ScoreText(Text scoreText)
    {
        this.scoreText.text = scoreText.text;
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
    public void CoinsText(Text coinsText)
    {
        this.coinsText.text = coinsText.text;
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
    }
    /// <summary>
    /// call when player resumes game
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    #endregion


}
