#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviourPun
{
    private short laps=3;//laps of this game
    private short currentLap = 0;//current going lap
    private bool winnerFound;
    private void Start()
    {
        winnerFound = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lap"))//check for lap tag 
        {
            if (base.photonView.IsMine)//check owner
            {
                currentLap++;//increase current lap
                GameUI.Instance.LapText(currentLap);//change  currentlap text
                if (currentLap >= laps)//check current lap is greater than laps 
                {
                    Master.GameSettings.Winner = photonView.Controller;
                    
                    print(winnerFound);
                    if (Master.GameSettings.IsOver == false && Master.GameSettings.Winner == photonView.Controller && !winnerFound )
                    {
                        GameUI.Instance.Win();//winner is found}
                        winnerFound = true;
                    }
                    else
                    { 
                        GameUI.Instance.GameOver();
                    }
                }
            }
            Master.GameSettings.IsOver = winnerFound;
            print(Master.GameSettings.IsOver);
        }
    }
}
