using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int bonusCoins;

    public int BonusCoins { get => bonusCoins; }
}
