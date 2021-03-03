#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviourPun
{
    [Header("Camera")]
    [SerializeField]
    private Camera myCamera;
    private InstatiatePlayer player;
    [Header("")]
    [SerializeField]
    [Range(1, 10)]
    private float smoothFactor;// how smooth camera will move

    private void Start()
    {
        player = FindObjectOfType<InstatiatePlayer>();
        if (!photonView.IsMine)//check for owner
        {
            //Destroy(myCamera);//destroy other cameras from your scene 
            myCamera.enabled = false;//deactivate camera
            myCamera.transform.parent = null;
            Debug.Log(myCamera.transform.parent);
            
        }
    }
    /// <summary>
     /// take target position by offset and player position 
     /// smoothly move camera 
     /// </summary>
    void Follow()
    {
        Vector3 targetPos = player.Temp.transform.position;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
    private void FixedUpdate()
    {
        if (base.photonView.IsMine)
        {
            Follow();
        }
    }
}
