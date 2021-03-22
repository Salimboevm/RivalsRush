using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerController characterController;
    public int bonusSpeed;

    private void Awake()
    {
        characterController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //Checks if the player enters the collider and increses his movement speed.
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("speed boosted");
            characterController.movespeed += bonusSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)  //Checks if the player left the collider and reduces his movement speed to normal.
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("sppppppppppppppeeeed");
            Debug.Log("speed boosted");
            characterController.movespeed -= bonusSpeed;
        }
    }
}
