<<<<<<< HEAD
﻿#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
=======
﻿using System.Collections;
>>>>>>> parent of f024b86 (camera following)
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField]
<<<<<<< HEAD
    private Camera myCamera;
    private InstatiatePlayer player;
    private Transform target;
    [Header("")]
    [SerializeField]
    [Range(1, 10)]
    private float smoothFactor;// how smooth camera will move

    private void Start()
    {
        //player = FindObjectOfType<InstatiatePlayer>();
        //if (!photonView.IsMine)//check for owner
        //{
        //    //Destroy(myCamera);//destroy other cameras from your scene 
        //    //myCamera.enabled = false;//deactivate camera
        //    //myCamera.transform.parent = null;
        //    Debug.Log(myCamera.transform.parent);
        //    
        //}
        if (!photonView.IsMine)
        {
            Destroy(myCamera);
        }
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.target = player.transform;
                break;
            }
        }
    }
    /// <summary>
     /// take target position by offset and player position 
     /// smoothly move camera 
     /// </summary>
    void Follow()
    {
        //Vector3 targetPos = player.Temp.transform.position;
        //
        //Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        //transform.position = smoothPos;
        Vector3 targetPos = target.position;
        targetPos.z = -10f;
        
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPos;
        
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Follow();
        }
    }
=======
    private Vector2 maxFollowOffset = new Vector2(-1f, 6f);//maximum value of following offset
    [SerializeField]
    private Vector2 cameraVel = new Vector2(4f, 0.25f);//velocity of camera
    [SerializeField]
    private Transform playerTransform = null;
    //[SerializeField]
    //private CinemachineVirtualCamera virtualCamera = null;
>>>>>>> parent of f024b86 (camera following)
}
