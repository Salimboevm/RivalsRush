﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Transforms
{
    public static void DestroyChild(this Transform t, bool destroyImmediatly = false)
    {
        foreach(Transform child in t)
        {
            if (destroyImmediatly)
                MonoBehaviour.DestroyImmediate(child.gameObject);
            else
                MonoBehaviour.Destroy(child.gameObject);
        }
    }
}
