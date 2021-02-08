using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _text;

    private Player player;

    public Player Player { get => player; private set => player = value; }

    public void SetPlayer(Player playerInfo)
    {
        Player = playerInfo;

        SetPlayerText(player);
         
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {

        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("RandomNumber"))
            {

                SetPlayerText(targetPlayer);
            }
        }

    }
    void SetPlayerText(Player player)
    {
        int res = -1;

        if (player.CustomProperties.ContainsKey("RandomNumber")){
            res = (int)player.CustomProperties["RandomNumber"];
        }
        _text.text = res.ToString() + "," + Player.NickName;
    }
}
