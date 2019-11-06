using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float initialDelay = 3f;
    public float spawnTime = 3f;

    private bool hasInvoked;
    public Transform[] spawnPoints;

    void Update()
    {
        //Repeats the Spawner method with every delay
        if (GameManager.instance.isGameStarted && !hasInvoked)
        {
            InvokeRepeating("Spawner", initialDelay, spawnTime);
            hasInvoked = true;
        }
    }

    void Spawner()
    {
      
        // If the player has no health left...
        if (GameManager.instance.isGameOver)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }


}
