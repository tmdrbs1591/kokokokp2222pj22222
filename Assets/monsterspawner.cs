using UnityEngine;

public class monsterspawner : MonoBehaviour
{
    public GameObject monsterPrefab; // 일반 몬스터 프리팹
    public GameObject bossPrefab; // 보스 몬스터 프리팹
    public Transform spawnPoint; // 몬스터 스폰 지점
    public float minSpawnInterval = 1f; // 최소 몬스터 생성 간격
    public float maxSpawnInterval = 5f; // 최대 몬스터 생성 간격
    public Transform tower; // 타워의 트랜스폼
    public int bossThreshold = 10; // 타워 체력이 이 값 이하로 떨어질 때 보스 몬스터 스폰

    private float spawnTimer = 0f;
    private float currentSpawnInterval = 0f;
    private bool spawnedBoss = false; // 보스 몬스터가 스폰되었는지 여부

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
