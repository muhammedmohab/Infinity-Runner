using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePreFabs;
    private List<GameObject> activeTiles;
    private Transform playerT;
    private float spamZ = 0.0f;
    private float tileL = 9.0f;
    private int tileN = 7;
    private int lastPrefabIndex = 0;
    private float safeTile = 15.0f; // safeTile makes it waits 15m before starting to call delete function
    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>(); //List keeping track of all active tiles to be deleted 
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i=0 ; i<tileN ; i++)
        {
            if (i < 1)
                spamTile(0);//Clean or start tile
            else
                spamTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerT.position.z - safeTile > (spamZ - tileN * tileL))
        {
            spamTile();

            deleteTile();
        }

    }
    
    void spamTile(int prefabIndex = -1) //prefabIndex = -1 means pick a random prefab to place.
    {
        
        GameObject go;
        //All tiles spawn under tilemanager object
        if (prefabIndex == -1)
            go = Instantiate(tilePreFabs[randomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePreFabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spamZ;
        //Start spawning tiles after the length of the first
        spamZ += tileL;
        //Adding the tiles to the list activeTiles to keep track of tiles to be deleted.
        activeTiles.Add(go);
    }

    //random function to not make the same prefab 2 times in a row
    int randomPrefabIndex()
    {
        //if it chooses the same prefab we had it last time it go into while and choose another one until it comes
        //up with a new one.
        int randomIndex = lastPrefabIndex;

        if (tilePreFabs.Length <= 1)
            return 0;
        
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePreFabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
