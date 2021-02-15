using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName ="Singleton/Master")]
public class Master : ScriptableObjectSingleton<Master>
{

    [SerializeField]
    private GameSettings _gameSettings;

    [SerializeField]
    private List<NetworkPrefab> networkPrefabs = new List<NetworkPrefab>();
    public static GameSettings GameSettings { get
        {
            return Instance._gameSettings;
        } 
    }
    public static GameObject NetworkInstantiate(GameObject go, Vector3 pos, Quaternion rot)
    {
        foreach (NetworkPrefab networkPrefab in Instance.networkPrefabs)
        {
            if (networkPrefab.Prefab == go)
            {
                if (networkPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefab.Path, pos, rot);
                    return result;
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

    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkPrefabs()
    {
#if UNITY_EDITOR
        Instance.networkPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance.networkPrefabs.Add(new NetworkPrefab(results[i], path));
            }
        }
#endif

    }
}
