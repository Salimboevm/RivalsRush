using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchForce;
    public bool onTop;
    GameObject bouncer;

    Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "jucator")
        {
            anim.SetBool("IsStepped", true);
            Debug.Log("weeeeeeeeeeeeeeeeeeee");
            rb.velocity = Vector2.up * launchForce;
        }
    }*/

    private void OnCollisionStay2D(Collision2D collision)  //Checks if the player is in the collider and activates the tranpoline and the Push()
    {
        if(onTop = true && collision.gameObject.tag == "Player")
        {
            Debug.Log(onTop + "??");
            bouncer = collision.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //Checks if the player entered the collider and turns off the trampoline
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("IsStepped", true);
            Debug.Log("Inside");
            Debug.Log(onTop + "in");
            onTop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)  //Checks if the player left the collider and turns off the trampoline
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Outside");
            Debug.Log(onTop + "out");
            onTop = false;
            anim.SetBool("IsStepped", false);
        }
    }

    void Push()
    {
        rb.velocity = Vector2.up * launchForce;
    }
}
