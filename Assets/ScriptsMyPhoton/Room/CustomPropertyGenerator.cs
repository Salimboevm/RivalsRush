#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPropertyGenerator : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable customProperty = new ExitGames.Client.Photon.Hashtable();//hashstable custom property 
    [SerializeField]
    private Text text;//players number
    /// <summary>
    /// funt to set customer number
    /// </summary>
    void SetCustomerNumber()
    {
        System.Random rnd = new System.Random();//system random number generator
        int result = rnd.Next(0, 99);//get random number

        text.text = result.ToString();//initialize it with text 

        customProperty["RandomNumber"] = result;//custom property is equal to result 
        PhotonNetwork.SetPlayerCustomProperties(customProperty);
//        PhotonNetwork.LocalPlayer.CustomProperties = customProperty;
    }
    /// <summary>
    /// func to set customer number
    /// call it from button 
    /// </summary>
    public void OnClickButton()
    {
        SetCustomerNumber();
    }
}
