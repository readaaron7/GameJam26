
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

    

    private Vector3 currentPosition = new Vector3(32f, -5 ,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        SpawnRandomRoom(biome1Rooms, biome1RoomCount);
        SpawnRandomRoom(biome2Rooms, biome2RoomCount);
    }

    private void SpawnRandomRoom(GameObject[] biomeRooms, int biomeRoomCount)
    {
        int[] counting_arr = new int[biomeRooms.Length]; // counting array

        // iterates thorugh all biome rooms
        for (int i = 0; i < biomeRoomCount; i++)
        {
            bool valid = false;
            int randIndex = 0;

            do
            {
                // generates a random index
                randIndex = Random.Range(0, biomeRooms.Length);

                if (counting_arr[randIndex] == 0)
                {
                    counting_arr[randIndex]++;
                    valid = true;
                }
            
            } while(!valid);
            
            

            // makes a copy of this game object and puts it into the scene
            // copies the combat room prefab at randIndex, places it at the current
            // position, and puts it at rotation 0 degrees
            Instantiate(biomeRooms[randIndex], currentPosition, Quaternion.identity);

            currentPosition.x += roomWidth;
        }
    }
}
