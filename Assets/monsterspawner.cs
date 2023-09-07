using UnityEngine;

public class monsterspawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ������ ���� ������
    public Transform spawnPoint; // ���� ����
    public float minSpawnInterval = 1f; // �ּ� ���� ���� ����
    public float maxSpawnInterval = 5f; // �ִ� ���� ���� ����

    private float spawnTimer = 0f;
    private float currentSpawnInterval = 0f;

    private void Start()
    {
        // ���� ���� �� ������ ���� ���� ���� ����
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnMonster();
            spawnTimer = 0f;

            // ���� ���� ���� ���� ����
            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnMonster()
    {
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
