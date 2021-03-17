using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///monobehaviourpun is for movement of each object is done by its owner 
/// </summary>
public class controller : MonoBehaviourPun
{
    public float speed; //how fast player will move
    public float jumpforce; //force of the jump
    public Transform checkceiling; //checks for a ceiling
    public Transform groundcheck; //checks for ground
    public LayerMask grounds; //define layers
    public float radiuscheck; //checks the radius
    private Rigidbody2D rb; //refernece rigidbody
    private bool right = true; //player is facing right is true
    private float movedirect; //what direction player will move
    private bool checkjump = false;//player jmumping is false
    private bool onground; //checks if player on ground



   void Awake() 
    {
        rb = GetComponent<Rigidbody2D>(); //check for rigidbody2d
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            //photonView.ViewID = Master.GameSettings.Id;
            GameUI.Instance.UserId.text = base.photonView.ViewID.ToString();
        }
    }
    void Update()
    {
        if (base.photonView.IsMine)//check who is owner
        {
            movedirect = Input.GetAxis("Horizontal"); //movement on horizontal scale

            if (Input.GetButtonDown("Jump") && onground) //check player is on ground
            {
                checkjump = true; //if button to jump is pressed player willl jump
            }

            if (movedirect > 0 && !right)//if facing left then player character flips right
            {
                playerflip();
            }
            else if (movedirect < 0 && right)//if facing right player flips left
            {
                playerflip();
            }

            rb.velocity = new Vector2(movedirect * speed, rb.velocity.y); //sets the velocity

            if (checkjump)//if player jumps force is applied
            {
                //rb.AddForce(new Vector2(0f, jumpforce)); //adds force to jump
            }

            checkjump = false;

            onground = Physics2D.OverlapCircle(groundcheck.position, radiuscheck, grounds);

        }
    }


    void playerflip() //method to flip the player to face the other way
    {
        right = !right; //inverse
        transform.Rotate(0f, 180f, 0f); //rotate 180 on the y axis
    }
}
