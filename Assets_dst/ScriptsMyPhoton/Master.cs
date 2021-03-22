#region Author
//Author: Mokhirbek Salimboev
//SID: 1919019
//Last Edited: 27/02/21
#endregion
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName ="Singleton/Master")]//scriptable object
public class Master : ScriptableObjectSingleton<Master>
{

    [SerializeField]
    private GameSettings _gameSettings;//game settings script
  
    [SerializeField]
    private List<NetworkPrefab> networkPrefabs = new List<NetworkPrefab>();//list of prefabs which could be instantiated 
    //property for game settings
    public static GameSettings GameSettings { get
        {
            return Instance._gameSettings;
        } 
    }


    /// <summary>
    /// function for instantiate player gameobjects
    /// </summary>
    /// <param name="go"></param>
    /// <param name="pos"></param>
    /// <param name="rot"></param>
    /// <returns></returns>
    public static GameObject NetworkInstantiate(GameObject go, Vector3 pos, Quaternion rot)
    {
        foreach (NetworkPrefab networkPrefab in Instance.networkPrefabs)//loop throgh network prefabs
        {
            if (networkPrefab.Prefab == go)//if network prefab is equal to game object
            {
                if (networkPrefab.Path != string.Empty)//adn we have a path
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefab.Path, pos, rot);//instantiate it by its name
                    return result;//return instantiated go
                }
            }
            else
            {
                Debug.Log("Path is empty");
                return null;
            }
        }

        return null;
    }

    /// <summary>
    /// function for populate network prefabs/player objects
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkPrefabs()
    {
        //runs only in the Editor
#if UNITY_EDITOR
        Instance.networkPrefabs.Clear();//clear all of the prefabs

        GameObject[] results = Resources.LoadAll<GameObject>("");//get all of the game objects from resources foulder
        for (int i = 0; i < results.Length; i++)//loop through results
        {
            if (results[i].GetComponent<PhotonView>() != null)//check it is not null
            {
                string path = AssetDatabase.GetAssetPath(results[i]);//get game objects path
                Instance.networkPrefabs.Add(new NetworkPrefab(results[i], path));//add it to network prefabs/player game objects
            }
        }
#endif

    }
}
