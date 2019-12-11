using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    public GameObject level;
    //how far away do we the platforms to spawn away from each other
    public float spawnDistance = 29;
    //the height variance of how the platforms spawn
    public Vector2 levelPlatformSpawnHeightRange = new Vector2(-5f, 5f);
    //how high the previous platform was spawned at *used to determine if the player could possibly jump to the next platform
    private float previousHeight;
    //how high can the player jump
    public float jumpableHeight = 2.5f;

    public GameObject[] obstaclesAndPickups;
    public GameObject scrollingLevel;

    private void Awake()
    {
        _objectPooler = FindObjectOfType<ObjectPooler>();
        StartCoroutine(SpawnRandom());
    }

    //if we have reached the end of a platform then we want to spawn the next one
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("PlatformEnd")))
        {
            //choose a random height to spawn it
            float randomSpawnHeight = Random.Range(levelPlatformSpawnHeightRange[0], levelPlatformSpawnHeightRange[1]);
            
            //make sure the platform is actually reachable for the player
            if (previousHeight + jumpableHeight < randomSpawnHeight)
            {
                randomSpawnHeight = previousHeight + jumpableHeight;
            }
            
            previousHeight = randomSpawnHeight;
            _objectPooler.GetObjectFromPool(new Vector2(level.transform.position.x + spawnDistance, randomSpawnHeight));
        }
    }

    IEnumerator SpawnRandom()
    {
        float timeToSpawnNext = Random.Range(0.1f, 8f);
        yield return new WaitForSeconds(timeToSpawnNext);
        int randomItem = Random.Range(0, obstaclesAndPickups.Length);
        var levelPosition = level.transform.position;
        GameObject spawnedItem = Instantiate(obstaclesAndPickups[randomItem],
            new Vector2(levelPosition.x + spawnDistance, levelPosition.y + 5),
            level.transform.rotation);
        spawnedItem.gameObject.transform.parent = scrollingLevel.transform;
        StartCoroutine(SpawnRandom());
    }
}
