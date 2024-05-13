using UnityEngine;

public class SplatMapPainter : MonoBehaviour
{
    public Terrain terrain; // Reference to your terrain object
    public Texture2D splatAlphaMap; // The pre-made splat alpha map texture

    void Start()
    {
        ApplySplatAlphaMap();
    }

    void ApplySplatAlphaMap()
    {
        TerrainData terrainData = terrain.terrainData;
        int splatmapWidth = splatAlphaMap.width;
        int splatmapHeight = splatAlphaMap.height;

        // Get the existing splat alpha map
        float[,,] splatmapData = new float[splatmapHeight, splatmapWidth, terrainData.alphamapLayers];

        // Iterate through the splat alpha map and assign textures based on the alpha values
        for (int x = 0; x < splatmapWidth; x++)
        {
            for (int y = 0; y < splatmapHeight; y++)
            {
                Color splatColor = splatAlphaMap.GetPixel(x, y);
                float total = splatColor.r + splatColor.g + splatColor.b;
                splatmapData[y, x, 0] = splatColor.r / total; // Assigning texture 1
                splatmapData[y, x, 1] = splatColor.g / total; // Assigning texture 2
                splatmapData[y, x, 2] = splatColor.b / total; // Assigning texture 3
            }
        }

        // Apply the modified splat alpha map back to the terrain
        terrainData.SetAlphamaps(0, 0, splatmapData);

        // Assign textures to the terrain material
        terrain.materialTemplate.SetTexture("_Control", splatAlphaMap);
        // Assuming your textures are named "Texture1", "Texture2", "Texture3"
        terrain.materialTemplate.SetTexture("_Splat0", Resources.Load<Texture2D>("Texture1"));
        terrain.materialTemplate.SetTexture("_Splat1", Resources.Load<Texture2D>("Texture2"));
        terrain.materialTemplate.SetTexture("_Splat2", Resources.Load<Texture2D>("Texture3"));
    }
}
