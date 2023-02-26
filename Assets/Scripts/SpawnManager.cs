using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PreSetupManager;

public class SpawnManager : MonoBehaviour
{
    public Difficulty difficulty;
    public GameObject container; 

    [Header("Spawnpoints")]
    public Spawnpoint spawnpoints;

    [Header("Prefabs")]
    public Spawnpoint easy, medium, hard;
    
    void Start()
    {
        init();
    }

    void init()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                spawnPrefabs(easy, spawnpoints);
                break;
            case Difficulty.MEDIUM:
                spawnPrefabs(medium, spawnpoints);
                break;
            case Difficulty.HARD:
                spawnPrefabs(hard, spawnpoints);
                break;
        }
    }

    void spawnPrefabs(Spawnpoint prefabs, Spawnpoint spawnpoints)
    {
        instantiatePrefab(prefabs.craftingTable, spawnpoints.craftingTable);
        instantiatePrefab(prefabs.furnace, spawnpoints.furnace);
        instantiatePrefab(prefabs.storage, spawnpoints.storage);
        instantiatePrefab(prefabs.trash, spawnpoints.trash);
        Instantiate(prefabs.tilemap, spawnpoints.tilemap.transform);
    }

    void instantiatePrefab(GameObject obj, GameObject spawnpoint)
    {
        GameObject instance = Instantiate(obj,container.transform);
        instance.transform.position = spawnpoint.transform.position;
    }

    [System.Serializable]
    public struct Spawnpoint
    {
        public GameObject craftingTable, furnace, storage, trash, tilemap;
    }


}
