using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float movespeed = 2; //defines the variable for move speed
    public float forcejump = 2; //defines the variable for the force of a jump
    private float movedirect; //what direction player will move
    private bool right = true; //player is facing right is true
    //[SerializeField]
    private Rigidbody2D _rigidbody; //references the rigidbody
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();//find the rigidbody2d
    }

    // Update is called once per frame
    void Update()
    {
        movedirect = Input.GetAxis("Horizontal"); //enables movement on the horizontal axis 
        transform.position += new Vector3(movedirect, 0,0) * Time.deltaTime * movespeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) <0.001f)//if the button is down the jump will initiate
        {
            _rigidbody.AddForce(new Vector2(0, forcejump), ForceMode2D.Impulse); //enabled jumping
        }

        if (movedirect > 0 && !right)//if facing left then player character flips right
        {
            playerflip();
        }
        else if (movedirect < 0 && right)//if facing right player flips left
        {
            playerflip();
        }
    }
    void playerflip() //method to flip the player to face the other way
    {
        right = !right; //inverse
        _rigidbody.transform.Rotate(0f, 180f, 0f); //rotate 180 on the y axis
    }
}
