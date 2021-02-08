using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _userName= "";
    public string UserName
    {
        get
        {
            int val = Random.Range(0, 999999);
            return _userName + val.ToString();
        }
    }
}
