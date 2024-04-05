using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public GameObject pathTilePrefab; // Prefab for the path tile
    public float generationThreshold = 10f; // Distance from the end of the path to trigger generation
    public float tileLength = 20f; // Length of each path tile

    private GameObject lastTile; // Reference to the last generated tile

    void Start()
    {
        if (lastTile == null && pathTilePrefab != null)
        {
            // Initialize the path with a starting tile
            lastTile = Instantiate(pathTilePrefab, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (lastTile != null)
        {
            // Check if the player (or this GameObject) is approaching the end of the path
            if (Vector3.Distance(transform.position, lastTile.transform.position) < generationThreshold)
            {
                GenerateTile();
            }
        }
        else
        {
            Debug.LogError("LastTile reference is missing. Please assign a starting tile.");
        }
    }

    void GenerateTile()
    {
        // Ensure there's a prefab to instantiate
        if (pathTilePrefab != null)
        {
            // Instantiate a new path tile at the end of the current path
            Vector3 spawnPosition = lastTile.transform.position + new Vector3(0f, 0f, tileLength);
            lastTile = Instantiate(pathTilePrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("PathTilePrefab is missing. Please assign a prefab to generate tiles.");
        }
    }
}

