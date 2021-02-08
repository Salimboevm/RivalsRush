using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;
    public static T Instance
    {
        get 
        {
            if (_instance==null)
            {
                T[] res = Resources.FindObjectsOfTypeAll<T>();
                if(res.Length == 0)
                {
                    Debug.LogError("There is no Singleton Scriptable object" + typeof(T).ToString());
                    return null;
                }
                if (res.Length > 1)
                {
                    Debug.LogError("Found more than 1 instance" + typeof(T).ToString());
                    return null;
                }

                _instance = res[0];
            }
            return _instance;
        }
    }
}
