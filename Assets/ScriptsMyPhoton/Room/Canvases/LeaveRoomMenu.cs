using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private CanvasesController canvasesController;

    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;
    }

    public void OnClickLeave()
    {
        PhotonNetwork.LeaveRoom(true);
        canvasesController.CurrentRoom.Hide();
    }


}

