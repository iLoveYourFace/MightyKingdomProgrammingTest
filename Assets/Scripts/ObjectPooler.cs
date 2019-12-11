using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
     public GameObject[] objectToPool;
     //How many of *each* object you want to pool
     public int poolSize;
 
     private List<GameObject> pooledObjects = new List<GameObject>();
 
     void Awake ()
     {
         //Create a pool of objects inside the scene object "_Dynamics"
         for (int j = 0; j < objectToPool.Length; j++)
         {
             for(int i = 0; i < poolSize; i++)
             {
                 GameObject obj = Instantiate(objectToPool[j], transform);
                 obj.transform.parent = GameObject.Find("_Dynamics").transform;
                 obj.SetActive(false);
                 pooledObjects.Add(obj);
             }
         }
     }
 
     //Fetch an inactive object from the object pool > Move the object to the spawnPoint vector3 > Set the fetched object to active
     public void GetObjectFromPool(Vector2 spawnPoint)
     {
         //Randomizing what object is spawned
         int randomObject = Random.Range(0, pooledObjects.Count);
         
         if (pooledObjects[randomObject].activeInHierarchy != true)
         {
             GameObject spawnedGameObject = pooledObjects[randomObject]; 
             spawnedGameObject.transform.position = spawnPoint;
             spawnedGameObject.SetActive(true);
         }
         else
         {
             for(int i = 0; i < poolSize; i++)
             {
                 if (pooledObjects[i].activeInHierarchy != true)
                 {
                     pooledObjects[i].transform.position = spawnPoint;
                     pooledObjects[i].gameObject.SetActive(true);
                     break;
                 }
             }
         }
     }
}
