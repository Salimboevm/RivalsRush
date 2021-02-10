using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ListingRoomsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing prefabListing;

    private List<RoomListing> roomListings = new List<RoomListing>();

    private CanvasesController canvasesController;

    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;
    }
    public override void OnJoinedRoom()
    {
        canvasesController.CurrentRoom.Show();
        //content.DestroyChild();
        roomListings.Clear();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            //remove from the list
            if (info.RemovedFromList)
            {
                int index = roomListings.FindIndex(x => x.roomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(roomListings[index].gameObject);
                    roomListings.RemoveAt(index);
                }
            }
            //add it to the list
            else
            {
                int index = roomListings.FindIndex(x => x.roomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = Instantiate(prefabListing, content);
                    if (listing != null)
                    {
                        listing.SetRoom(info);
                        roomListings.Add(listing);
                    }
                }
            }
        }
    }
}
