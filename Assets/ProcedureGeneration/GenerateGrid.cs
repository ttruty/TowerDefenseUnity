using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] private GameObject blockGameObject;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject player;


    [SerializeField] private int worldSizeX = 40;
    [SerializeField] private int worldSizeZ = 40;
    [SerializeField] private int noiseHeight = 5;
    [SerializeField] private float gridOffset = 1.1f;
    
    private Vector3 startPosition;
    private Hashtable blockContainer = new Hashtable();
    private List<Vector3> blockPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid(startPosition);
        //SpawnObject();
    }

    private void Update() {
        if (Mathf.Abs(xPlayerMove) >= 1 || Mathf.Abs(zPlayerMove) >= 1) {
            Vector3 playerPos = new Vector3(xPlayerLocation, 0, zPlayerLocation);
            CreateGrid(playerPos);
        }
    }

    private void CreateGrid(Vector3 position) {
        for (int x = -worldSizeX; x < worldSizeX; x++ ) {
            for (int z = -worldSizeZ; z < worldSizeZ; z++) {
                Vector3 pos = new Vector3(x * 1 + position.x,
                GeneratedNoise(x + (int)position.x, z + (int)position.z , 8f) * noiseHeight, 
                z * 1 + position.z);

            if (!blockContainer.ContainsKey(pos)) {
                GameObject block = Instantiate(blockGameObject, pos, Quaternion.identity) as GameObject;
                
                blockContainer.Add(pos, block);
                blockPositions.Add(block.transform.position);
                block.transform.SetParent(this.transform);
                }
            }
        }
    }

    public int xPlayerMove {
        get {
            return (int)(player.transform.position.x);
        }
    }
    public int zPlayerMove {
        get {
            return (int)(player.transform.position.z);
        }
    }
    private void SpawnObject() {
        for (int i = 0; i < 20; i++) {
            GameObject toPlaceObject = Instantiate(objectToSpawn,
            ObjectSpawnLocation(), Quaternion.identity);
        }
    }

       public int xPlayerLocation {
        get {
            return (int)Mathf.Floor(player.transform.position.x);
        }
    }
    public int zPlayerLocation {
        get {
            return (int)Mathf.Floor(player.transform.position.z);
        }
    }


    private Vector3 ObjectSpawnLocation() {
        int randomIndex = Random.Range(0, blockPositions.Count);
        Vector3 newPos = new Vector3 (
            blockPositions[randomIndex].x,
            blockPositions[randomIndex].y + 0.5f,
            blockPositions[randomIndex].z
        );
        blockPositions.RemoveAt(randomIndex);
        return newPos;
    }

    private float GeneratedNoise(int x, int z, float detailScale) {
        float xNoise = (x + this.transform.position.x) / detailScale;
        float zNoise = (z + this.transform.position.y) / detailScale;

        return Mathf.PerlinNoise(xNoise, zNoise);
    }
}
