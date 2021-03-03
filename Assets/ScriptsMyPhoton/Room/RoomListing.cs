#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
/// <summary>
/// class to list rooms
/// </summary>
public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;//text obj accessable from editor

    public RoomInfo roomInfo { get; private set; }//property for roominfo
 
    /// <summary>
    /// funct to set room 
    /// </summary>
    /// <param name="roomInfo">information abt the room</param>
    public void SetRoom(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;//initialize property room info with given room info
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;//change text to room`s name and max players
    }
    /// <summary>
    /// func to join room 
    /// call it from editor button
    /// </summary>
    public void OnClickButton()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);//join to room with given info
    }
}
