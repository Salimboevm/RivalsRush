using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField]
    private Vector2 maxFollowOffset = new Vector2(-1f, 6f);//maximum value of following offset
    [SerializeField]
    private Vector2 cameraVel = new Vector2(4f, 0.25f);//velocity of camera
    [SerializeField]
    private Transform playerTransform = null;
    //[SerializeField]
    //private CinemachineVirtualCamera virtualCamera = null;
}
