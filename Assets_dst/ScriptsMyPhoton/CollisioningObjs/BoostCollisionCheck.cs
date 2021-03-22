using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// class to check collision entering 
/// and change ui 
/// </summary>
public class BoostCollisionCheck : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// func to check trigger entering with player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "booster")//check to tag of obj
        {
            //if it is booster
            if (base.photonView.IsMine)//check to owner
            {
                GameUI.Instance.BoostUpdate();//update booster ui text and image
            }
        }
    }

}
