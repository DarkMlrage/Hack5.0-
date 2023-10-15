using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // ����� ��'����, �� ����� ��������.
    public Transform[] spawnPoints; // ����� �����, � ���� ����� �������� ��'����.
    public int minObjectsToSpawn = 1; // ̳������� ������� ��'���� ��� ������.
    public int maxObjectsToSpawn = 5; // ����������� ������� ��'���� ��� ������.

    public float minSpawnInterval = 5f; // ̳�������� �������� �� ��������.
    public float maxSpawnInterval = 20f; // ������������ �������� �� ��������.

    private float nextSpawnTime;

    private void Start()
    {
        // ���������� ������ ��� ������.
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        // ����������, �� ������ ��� ��� ������ ��'����.
        if (Time.time >= nextSpawnTime)
        {
            SpawnObjects();
            // �������� ����� ��� ��� ���������� ������.
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnObjects()
    {
        // �������� ��������� ������� ��'���� ��� ������.
        int objectsCount = Random.Range(minObjectsToSpawn, maxObjectsToSpawn + 1);

        for (int i = 0; i < objectsCount; i++)
        {
            // �������� ���������� ��'��� �� ����� ������.
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // �������� ��'��� � ������� �����.
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
