using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefab
{
    //variables to assign
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string path;

    //properties to get them out of script
    public GameObject Prefab { get => prefab; set => prefab = value; }
    public string Path { get => path; set => path = value; }

    //custom constructor
    public NetworkPrefab(GameObject prefab, string path)
    {
        this.prefab = prefab;
        this.path = ReturnPrefabPath(path);
    }
    private string ReturnPrefabPath(string path)
    {
        int extensionLength = System.IO.Path.GetExtension(path).Length;
        int additional = 10;
        int startIndex = path.ToLower().IndexOf("resources");

        if(startIndex == -1)
        {
            return string.Empty;
        }
        else
        {
            return path.Substring(startIndex + additional, path.Length - (additional+startIndex + extensionLength));
        }
    }
}
