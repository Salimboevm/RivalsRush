using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviourPun
{

    void Awake()
    {
        //bonusScore = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)  //Checks if the player collides with the coin , destroys it and give a certain amount of points to the player based on the coin.
    {
        if (collision.gameObject.tag == "Coins")
        {
            if (base.photonView.IsMine)
            {
                Debug.Log("Collide");
                GameUI.Instance.CoinsText(FindObjectOfType<Coin>().BonusCoins);
            }
            Destroy(collision.gameObject);
        }
    }

}
