using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiatePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        Master.NetworkInstantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
