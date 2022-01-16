using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance { get; private set; }
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    [SerializeField] private List<GameObject> pooledObjects2;
    [SerializeField] private GameObject objectToPool2;
    [SerializeField] private int amountToPool2;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects, deactivating them and adding them to the list 
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool, Vector2.zero, new Quaternion(0, 0, 0, 0));
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }

        pooledObjects2 = new List<GameObject>();
        for (int i = 0; i < amountToPool2; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool2);
            obj.SetActive(false);
            pooledObjects2.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public GameObject GetPooledObject2()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects2.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        // otherwise, return null   
        return null;
    }

}
