using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiatePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    GameObject temp;

    public GameObject Temp { get => temp; }

    private void Awake()
    {
        Vector2 offset = Random.insideUnitCircle * 3f;
        Vector3 pos = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);
        Master.NetworkInstantiate(playerPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
