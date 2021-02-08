using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerListing prefabListing;

    private List<PlayerListing> roomListings = new List<PlayerListing>();

    private CanvasesController canvasesController;

    public void Initialize(CanvasesController canvasesController)
    {
        this.canvasesController = canvasesController;
    }
    public override void OnEnable()
    {
        
        CurrentRoomPlayers();

    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < roomListings.Count; i++)
        {
            Destroy(roomListings[i].gameObject);
        }
        roomListings.Clear();
    }
    private void CurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player newPlayer)
    {
        int index = roomListings.FindIndex(x => x.Player == newPlayer);
        if (index != -1)
        {
            roomListings[index].SetPlayer(newPlayer);
        }
        else
        {
            PlayerListing listing = Instantiate(prefabListing, content);
            if (listing != null)
            {
                listing.SetPlayer(newPlayer);
                roomListings.Add(listing);
            }
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = roomListings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(roomListings[index].gameObject);
            roomListings.RemoveAt(index);
        }
    }
    public void OnClickLoadLevel(int index)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(index);
        }
    }
}
