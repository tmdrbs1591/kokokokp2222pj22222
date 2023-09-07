using UnityEngine;

public class monsterspawner : MonoBehaviour
{
    public GameObject monsterPrefab; // �Ϲ� ���� ������
    public GameObject bossPrefab; // ���� ���� ������
    public Transform spawnPoint; // ���� ���� ����
    public float minSpawnInterval = 1f; // �ּ� ���� ���� ����
    public float maxSpawnInterval = 5f; // �ִ� ���� ���� ����
    public Transform tower; // Ÿ���� Ʈ������
    public int bossThreshold = 10; // Ÿ�� ü���� �� �� ���Ϸ� ������ �� ���� ���� ����

    private float spawnTimer = 0f;
    private float currentSpawnInterval = 0f;
    private bool spawnedBoss = false; // ���� ���Ͱ� �����Ǿ����� ����

    private void Start()
    {
       
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (!spawnedBoss && spawnTimer >= currentSpawnInterval)
        {
            if (tower != null && tower.GetComponent<TowerHp>() != null)
            {
                int towerHp = (int)tower.GetComponent<TowerHp>().Thp;

                if (towerHp <= bossThreshold)
                {
                    
                    SpawnBossMonster();
                    spawnedBoss = true; 
                }
                else
                {
                    
                    SpawnNormalMonster();
                }
            }

            spawnTimer = 0f;

            
            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnNormalMonster()
    {
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void SpawnBossMonster()
    {
        Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
    }
}
