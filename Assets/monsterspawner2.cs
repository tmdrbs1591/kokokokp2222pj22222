using UnityEngine;

public class monsterspawner2 : MonoBehaviour
{
    public GameObject monsterPrefab; // ������ ���� ������
    public Transform spawnPoint; // ���� ����
    public float minSpawnInterval = 1f; // �ּ� ���� ���� ����
    public float maxSpawnInterval = 5f; // �ִ� ���� ���� ����

    private float spawnTimer = 0f;
    private float currentSpawnInterval = 0f;
    private bool isTowerDestroyed = false; // 1�� ��ž�� �ı��Ǿ����� ���θ� �����ϴ� ����

    private void Start()
    {
        // ���� ���� �� ������ ���� ���� ���� ����
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        // 1�� ��ž�� �ı��Ǿ��� �� ���͸� ��ȯ�ϵ��� Ȯ��
        if (isTowerDestroyed)
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
    }

    private void SpawnMonster()
    {
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }

    // 1�� ��ž�� �ı��Ǿ��� �� ȣ���� �޼���
    public void OnTowerDestroyed()
    {
        isTowerDestroyed = true;
    }
}
