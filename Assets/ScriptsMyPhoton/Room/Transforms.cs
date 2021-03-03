#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class for destroying child objs
/// </summary>
public static class Transforms
{
    /// <summary>
    /// func to destroy child objects
    /// </summary>
    /// <param name="t">parent transform component</param>
    /// <param name="destroyImmediatly">boolean to check do this script has to destroy it immediatly</param>
    public static void DestroyChild(this Transform t, bool destroyImmediatly = false)
    {
        foreach(Transform child in t)//loop through t parent 
        {
            if (destroyImmediatly)//if need to destroy immediately
                MonoBehaviour.DestroyImmediate(child.gameObject);//destroy it immediately 
            else//if not
                MonoBehaviour.Destroy(child.gameObject);//destroy it 
        }
    }
}
