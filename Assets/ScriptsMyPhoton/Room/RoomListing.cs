using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public RoomInfo roomInfo { get; private set; }
    public void SetRoom(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
    public void OnClickButton()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
