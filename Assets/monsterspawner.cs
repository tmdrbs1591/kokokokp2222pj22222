using UnityEngine;

public class monsterspawner : MonoBehaviour
{
    public GameObject monsterPrefab; // ������ ���� ������
    public Transform leftSpawnPoint; // ���� ���� ����
    public Transform rightSpawnPoint; // ������ ���� ����
    public float spawnInterval = 5f; // ���� ���� ����

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnMonster();
            spawnTimer = 0f;
        }
    }

    private void SpawnMonster()
    {
        // �����ϰ� ���� �Ǵ� ������ ���� ���� ����
        Transform spawnPoint = Random.Range(0, 2) == 0 ? leftSpawnPoint : rightSpawnPoint;

        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
