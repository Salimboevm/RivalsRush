using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _userName= "";
    [SerializeField]
    private int id;
    bool isOver = false;
    Player winner;
    public string UserName
    {
        get
        {
            int val = Random.Range(0, 999999);
            return _userName + val.ToString();
        }
    }
    
    public int Id { get => id; set => id = value; }
    public bool IsOver { get => isOver; set => isOver = value; }
    public Player Winner { get => winner; set => winner = value; }
}
