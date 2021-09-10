using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private int minDistanceToGenerate;
    [SerializeField] private List <TerrainData> terrainDates = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

    private readonly List<GameObject> currentTerrains = new List<GameObject>();
    public Vector3 currentPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0, 0, 0));
        }
        maxTerrainCount = currentTerrains.Count;
    }
    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if ((currentPosition.z - playerPos.z < minDistanceToGenerate) || (isStart))
        {
            int whichTerrain = Random.Range(0, terrainDates.Count);
            int terrainInSuccession = Random.Range(1, terrainDates[whichTerrain].maxInSuccesion);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDates[whichTerrain].possibleTerrain[Random.Range(0, 
                    terrainDates[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.z++;
            }
        }
    }
}
