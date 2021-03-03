using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)  //Checks if the player collides with the spikes and if it does , a penalty is applied.
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Hey it is entering");
            GameUI.Instance.TempCoins /= 2;
            print(GameUI.Instance.TempCoins);
        }
    }
}
