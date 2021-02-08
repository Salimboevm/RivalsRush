using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoom : MonoBehaviour
{
    [SerializeField]
    private CreateRoom createRoom;
    [SerializeField]
    private ListingRoomsMenu listingRoomsMenu;
    private CanvasesController canvasesController;

    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;
        createRoom.Initialize(canvasesController);
        listingRoomsMenu.Initialize(canvasesController);
    }
}
