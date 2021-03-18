using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviourPun, IPunObservable
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
        //Camera.main.GetComponent<CameraFollowing>().SetTarget(photonView.transform);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (base.photonView.IsMine)//check who is owner
        {
            
            movedirect = Input.GetAxis("Horizontal"); //enables movement on the horizontal axis 
            transform.position += new Vector3(movedirect, 0, 0) * Time.deltaTime * movespeed;

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)//if the button is down the jump will initiate
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

    }
    void playerflip() //method to flip the player to face the other way
    {
        right = !right; //inverse
        _rigidbody.transform.Rotate(0f, 180f, 0f); //rotate 180 on the y axis
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    stream.SendNext(transform.position);
        //    stream.SendNext(transform.rotation);
        //}
        //else if(stream.IsReading)
        //{
        //    transform.position = (Vector3)stream.ReceiveNext();
        //    transform.rotation = (Quaternion)stream.ReceiveNext();
        //}
    }
}
