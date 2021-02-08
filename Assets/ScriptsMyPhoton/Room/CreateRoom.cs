using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text roomName;
    
    private CanvasesController canvasesController;

    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;
    }
    public void OnClickCreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions opt = new RoomOptions();
        opt.BroadcastPropsChangeToAll = true;
        opt.PublishUserId = true;
        opt.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, opt, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room has been created succesfully", this);
        canvasesController.CurrentRoom.Show();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed" + message, this);
    }
}
