using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class Connect : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        AuthenticationValues authenticationValues = new AuthenticationValues("0");
        PhotonNetwork.AuthValues = authenticationValues;
        
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

