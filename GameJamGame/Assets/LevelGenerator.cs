
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Room Prefabs")]
    [SerializeField] private GameObject[] combatRooms;
    [SerializeField] private GameObject treasureRoom;
    [SerializeField] private GameObject bossRoom;

    [Header("Generation Settings")]
    [SerializeField] private int combatRoomCount;
    [SerializeField] private float roomWidth;

    private Vector3 currentPosition = new Vector3(29f, 0 ,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        SpawnRandomCombatRooms();
    }

    private void SpawnRandomCombatRooms()
    {
        for (int i = 0; i < combatRoomCount; i++)
        {
            // generates a random index
            int randIndex = Random.Range(0, combatRooms.Length);

            // makes a copy of this game object and puts it into the scene
            // copies the combat room prefab at randIndex, places it at the current
            // position, and puts it at rotation 0 degrees
            Instantiate(combatRooms[randIndex], currentPosition, Quaternion.identity);

            currentPosition.x += roomWidth;
        }
    }
}
