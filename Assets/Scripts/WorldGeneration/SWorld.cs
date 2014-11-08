using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SWorld
{
    // World relative
        public static GameObject world;
        // Player
        public static GameObject player;

        // Initial number of chunks
        public static IntVector3 chunkNumber = new IntVector3(8, 2, 8);
        // Space occupied by a chunk
        public static IntVector3 chunkSize = new IntVector3(16, 16, 16);
        // Chunks declaration
        public static ChunkGenerator[, ,] chunk;
        // Control the chunks we are going to reset
        public static List<IntVector3> chunksToReset = new List<IntVector3>();

    // 3D models relative
        // Enemies
        public static Transform normalSlime;
        public static string selectedEnemy = "Normal Slime";

        // Gadgets
        public static Transform woodPieces;
        public static Transform nails;
        public static string selectedGadget = "Wood Pieces";

    // Material and texture relative
        public static float textureSize = 128 / 1024.0f;

        public static string selectedTerrain = "Grass";
        public static string selectedMine = "Rock";

    // Voxel relative
        // The max sediments we can use before creating another voxel
        public static float maxSediment = 12;

        // Global counter of the vertices that are being used
        public static int vertexCount;

    // Save relative
        public static string saveName;

    
}
