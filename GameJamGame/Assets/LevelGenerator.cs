
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Room Prefabs")]
    [SerializeField] private GameObject[] biome1Rooms;
    [SerializeField] private GameObject[] biome2Rooms;
    [SerializeField] private GameObject[] biome3Rooms;
    [SerializeField] private GameObject treasureRoom;
    [SerializeField] private GameObject bossRoom;

    [Header("Generation Settings")]
    [SerializeField] private int biome1RoomCount;
    [SerializeField] private int biome2RoomCount;
    [SerializeField] private int biome3RoomCount;
    
    [SerializeField] private float roomWidth;
    [SerializeField] private float roomHeight;

    private Vector3 biome2StartPos;
    private Vector3 biome3StartPos;
    private Vector3 biome1StartPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        biome1StartPos = new Vector3(11f, -5 ,0);
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        // determines which biome will spawn the boss room at the end
        int intSpawnBossRoom = Random.Range(0,2);
        bool boolSpawnBossRoom = false;
        if (intSpawnBossRoom == 1)
        {
            boolSpawnBossRoom = true;
        }
        // generate biome 1 rooms
        GenerateBiome(biome1Rooms, biome1RoomCount, biome1StartPos, false, true);

        // generate biome 2 above biome 1
        if (biome2StartPos != Vector3.zero)
        {
            biome2StartPos += Vector3.up * roomHeight;
            GenerateBiome(biome2Rooms, biome2RoomCount, biome2StartPos, boolSpawnBossRoom, false);
        }

        // generate biome 3 below biome 1
        if (biome3StartPos != Vector3.zero)
        {
            biome3StartPos += Vector3.down * roomHeight;
            GenerateBiome(biome3Rooms, biome3RoomCount, biome3StartPos, !boolSpawnBossRoom, false);
        }
    }

    private void GenerateBiome(GameObject[] biomeRooms, int biomeRoomCount, Vector3 startPosition, bool spawnBossRoom, bool isFirstBiome)
    {
        int[] counting_arr = new int[biomeRooms.Length]; // counting array
        
        // spawn first room in each biome (the same each time)
        Instantiate(biomeRooms[0], startPosition, Quaternion.identity);
        startPosition.x += roomWidth;
        counting_arr[0] = 1; // room 0 is used


        // iterates thorugh all biome rooms
        for (int i = 2; i < biomeRoomCount; i++)
        {
            bool valid = false;
            int randIndex = 0;

            do
            {
                // generates a random index
                randIndex = Random.Range(2, biomeRooms.Length);

                if (counting_arr[randIndex] == 0)
                {
                    counting_arr[randIndex]++;
                    valid = true;
                }
            
            } while(!valid);
            
            

            // makes a copy of this game object and puts it into the scene
            // copies the combat room prefab at randIndex, places it at the current
            // position, and puts it at rotation 0 degrees
            Instantiate(biomeRooms[randIndex], startPosition, Quaternion.identity);

            if (isFirstBiome)
            {
                if (randIndex == 3)
                {
                    biome2StartPos = startPosition;
                }
                else if (randIndex == 4)
                {
                    biome3StartPos = startPosition;
                }
            }
            

            startPosition.x += roomWidth;
        }

        if (spawnBossRoom)
        {
            // spawn boss room
            Instantiate(bossRoom, startPosition, Quaternion.identity);
        }
        else
        {
            // spawn ending room
            Instantiate(biomeRooms[1], startPosition, Quaternion.identity);
            counting_arr[2] = 1;
        }
    }
}
