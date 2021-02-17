using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
     
    private Score bonusScore;
    public int bonusCoins;

    void Awake()
    {
        bonusScore = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)  //Checks if the player collides with the coin , destroys it and give a certain amount of points to the player based on the coin.
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collide");
            Destroy(gameObject);
            bonusScore.Add(bonusCoins) ;
        }
    }

}
