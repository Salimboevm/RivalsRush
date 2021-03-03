#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
/// <summary>
/// class to list rooms menu
/// </summary>
public class ListingRoomsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;//parent content
    [SerializeField]
    private RoomListing prefabListing;//listing prefab to content

    private List<RoomListing> roomListings = new List<RoomListing>();//list of listing rooms

    private CanvasesController canvasesController;//canvas controller script to access canvases 

    /// <summary>
    /// func to initialize canvas controller
    /// </summary>
    /// <param name="canvasesController">requests canvas controller</param>
    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;//get canvas controller
    }
    /// <summary>
    /// func to control ui and roomlisting
    /// </summary>
    public override void OnJoinedRoom()
    {
        canvasesController.CurrentRoom.Show();//call show current room 
        //content.DestroyChild();
        roomListings.Clear();//clear room listings 
    }
    /// <summary>
    /// funt to update list of rooms 
    /// </summary>
    /// <param name="roomList">list of info abt rooms</param>
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)//loop through list 
        {
            //remove from the list
            if (info.RemovedFromList)
            {
                int index = roomListings.FindIndex(x => x.roomInfo.Name == info.Name);//get index
                if (index != -1)//check for index is not equal to -1
                {
                    Destroy(roomListings[index].gameObject);//if not destroy index from list of rooms
                    roomListings.RemoveAt(index);//remove from list
                }
            }
            //add it to the list
            else
            {
                int index = roomListings.FindIndex(x => x.roomInfo.Name == info.Name);//get index
                if (index == -1)//check to -1
                {
                    RoomListing listing = Instantiate(prefabListing, content);//make listing and initialize with newly Instantiated list of prefabs and parent is content
                    if (listing != null)//check listing to null
                    {
                        listing.SetRoom(info);//set room from listing
                        roomListings.Add(listing);//add listing to list of rooms
                    }
                }
            }
        }
    }
}
