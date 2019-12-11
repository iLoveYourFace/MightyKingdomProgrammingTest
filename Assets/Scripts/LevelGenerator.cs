using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    //all the prefabs that make up our level platforms
    public GameObject[] levelParts;
    public GameObject level;
    public GameObject scrollingLevel;
    //how far away do we the platforms to spawn away from each other
    public float spawnDistance = 29;
    //the height variance of how the platforms spawn
    public Vector2 levelPlatformSpawnHeightRange = new Vector2(-5f, 5f);
    //how high the previous platform was spawned at *used to determine if the player could possibly jump to the next platform
    private float previousHeight;
    //how high can the player jump
    public float jumpableHeight = 2.5f;

    //if we have reached the end of a platform then we want to spawn the next one
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("PlatformEnd")))
        {
            //choose a random piece to spawn
            int randomPart = Random.Range(0, levelParts.Length);
            //choose a random height to spawn it
            float randomSpawnHeight = Random.Range(levelPlatformSpawnHeightRange[0], levelPlatformSpawnHeightRange[1]);
            //make sure the platform is actually reachable for the player
            if (previousHeight + jumpableHeight < randomSpawnHeight)
            {
                randomSpawnHeight = previousHeight + jumpableHeight;
            }

            previousHeight = randomSpawnHeight;
            
            GameObject spawnedPlatform = 
                Instantiate(levelParts[randomPart], new Vector2(level.transform.position.x + spawnDistance, randomSpawnHeight), level.transform.rotation);
            spawnedPlatform.transform.parent = scrollingLevel.transform;
        }
    }
    
}
