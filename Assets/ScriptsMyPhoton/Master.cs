using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Singleton/Master")]
public class Master : ScriptableObjectSingleton<Master>
{

    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings GameSettings { get
        {
            return Instance._gameSettings;
        } 
    }
}
