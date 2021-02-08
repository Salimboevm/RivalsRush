using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //AuthenticationValues authenticationValues = new AuthenticationValues("0");
        //PhotonNetwork.AuthValues = authenticationValues;
        PhotonNetwork.SendRate = 70;
        PhotonNetwork.SerializationRate = 5;

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = Master.GameSettings.UserName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to server");
        print(PhotonNetwork.LocalPlayer.NickName);
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }
    
}

