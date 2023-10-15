using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Масив об'єктів, які можна спавнити.
    public Transform[] spawnPoints; // Масив точок, з яких можна спавнити об'єкти.
    public int minObjectsToSpawn = 1; // Мінімальна кількість об'єктів для спавну.
    public int maxObjectsToSpawn = 5; // Максимальна кількість об'єктів для спавну.

    public float minSpawnInterval = 5f; // Мінімальний інтервал між спавнами.
    public float maxSpawnInterval = 20f; // Максимальний інтервал між спавнами.

    private float nextSpawnTime;

    private void Start()
    {
        // Ініціалізуємо перший час спавну.
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        // Перевіряємо, чи настав час для спавну об'єктів.
        if (Time.time >= nextSpawnTime)
        {
            SpawnObjects();
            // Генеруємо новий час для наступного спавну.
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnObjects()
    {
        // Генеруємо випадкову кількість об'єктів для спавну.
        int objectsCount = Random.Range(minObjectsToSpawn, maxObjectsToSpawn + 1);

        for (int i = 0; i < objectsCount; i++)
        {
            // Вибираємо випадковий об'єкт та точку спавну.
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Спавнимо об'єкт у вибраній точці.
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
