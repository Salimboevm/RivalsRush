﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu playerListingMenu;
    [SerializeField]
    private LeaveRoomMenu leaveRoomMenu;

    private CanvasesController canvasesController;
    

    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;
        playerListingMenu.Initialize(canvasesController);
        leaveRoomMenu.Initialize(canvasesController);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
