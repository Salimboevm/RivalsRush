using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Transform player;
    [Header("")]
    [SerializeField]
    [Range(1, 10)]
    private float smoothFactor;// how smooth camera will move

    private void Start()
    {
        
    }
    private void Update()
    {
        if (player != null)
        {
            //transform.position = player.transform.position + new Vector3(0, 10, 20);
            Vector3 targetPos = player.transform.position;

            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
            transform.position = new Vector3(smoothPos.x, smoothPos.y, transform.position.z);
            
        }
    }
    public void SetTarget(Transform player)
    {
        this.player = player;
    }
}
