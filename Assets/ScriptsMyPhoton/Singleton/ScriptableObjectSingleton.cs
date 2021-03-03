#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class for scriptable objs  
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;//singleton of T
    //property field
    public static T Instance
    {
        get 
        {
            if (_instance==null)//check instance is null
            {
                T[] res = Resources.FindObjectsOfTypeAll<T>();//initialize T to all of the objects from resources folder
                if(res.Length == 0)//check length of T
                {
                    Debug.LogError("There is no Singleton Scriptable object" + typeof(T).ToString());//if it is null print error to console 
                    return null;
                }
                if (res.Length > 1)//if it is greater than 1
                {
                    Debug.LogError("Found more than 1 instance" + typeof(T).ToString());//print error to console
                    return null;
                }

                _instance = res[0];//initialize first element from found objects
            }
            return _instance;//returnt instance
        }
    }
}
