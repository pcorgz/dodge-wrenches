using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor;
using UnityEngine;

public class PreparePool : MonoBehaviour
{
    [SerializeField]
    private PooledMonoBehaviour[] prefabs = null;

    private void Awake()
    {
        foreach (var prefab in prefabs)
        {
            if (prefab == null)
            {
                Debug.LogError("Null prefab in PoolPreparer");
            }
            else
            {
                PooledMonoBehaviour poolablePrefab = prefab.GetComponent<PooledMonoBehaviour>();
                if (poolablePrefab == null)
                {
                    Debug.LogError("Prefab does not contain an IPoolable and can't be pooled");
                }
                else
                {
                    Pool.GetPool(poolablePrefab);
                }
            }
        }
    }

    private void OnValidate()
    {
        List<GameObject> prefabsToRemove = new List<GameObject>();

        var notNullPrefabs = prefabs.Where(t => t != null);
        foreach (var prefab in notNullPrefabs)
        {
            PooledMonoBehaviour poolablePrefab = prefab.GetComponent<PooledMonoBehaviour>();
            if (poolablePrefab == null)
            {
                Debug.LogError("Prefab does not contain an IPoolable and can't be pooled. It has been removed");
                prefabsToRemove.Add(prefab.gameObject);
            }
        }

        prefabs = prefabs
                .Where(t => t != null && prefabsToRemove.Contains(t.gameObject) == false)
                .ToArray();
    }
}
