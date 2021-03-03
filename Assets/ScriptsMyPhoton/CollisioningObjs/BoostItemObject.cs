using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostItemObject : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private string nameOfObj;//name of item which causes to boost player`s ability
    [SerializeField]
    private Sprite imageOfObj;//image of item which causes to boost player`s ability;
    #endregion
    #region Properties
    public string NameOfObj { get => nameOfObj; }
    public Sprite ImageOfObj { get => imageOfObj; }

    #endregion

}
