using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Terrain))]
public class Ocean : MonoBehaviour
{
    Terrain terrain;

    public float density;

    [SerializeField] int width, height, depth;
    [SerializeField] float scale;
    [SerializeField] float velX, velY;
    float cumx, cumy;
    // Start is called before the first frame update
    void Awake()
    {
        terrain = GetComponent<Terrain>();
    }

    private void Update()
    {
        cumx += velX * Time.deltaTime;
        cumy += velY * Time.deltaTime;
        PerlinDisplacement(); 
    }

    void PerlinDisplacement()
    {
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int i = 0; i < heights.GetLength(0); i++)
        {
            for (int j = 0; j < heights.GetLength(1); j++)
            {
                float xcoord = (float)i / width * scale + cumx;
                float ycoord = (float)j / height * scale + cumy;
                heights[i, j] = Mathf.PerlinNoise(xcoord, ycoord);
            }
        }
        return heights;
    }
}
