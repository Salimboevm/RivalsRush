using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPropertyGenerator : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable customProperty = new ExitGames.Client.Photon.Hashtable();
    [SerializeField]
    private Text text;

    void SetCustomerNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

        text.text = result.ToString();

        customProperty["RandomNumber"] = result;
        PhotonNetwork.SetPlayerCustomProperties(customProperty);
//        PhotonNetwork.LocalPlayer.CustomProperties = customProperty;
    }
    public void OnClickButton()
    {
        SetCustomerNumber();
    }
}
