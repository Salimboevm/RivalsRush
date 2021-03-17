#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion
using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviourPunCallBacks
{
    [Header("Camera")]
    [SerializeField]
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
}
