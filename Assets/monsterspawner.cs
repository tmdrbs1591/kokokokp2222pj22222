using UnityEngine;

public class monsterspawner : MonoBehaviour
{
    public GameObject monsterPrefab; // 생성할 몬스터 프리팹
    public Transform spawnPoint; // 스폰 지점
    public float minSpawnInterval = 1f; // 최소 몬스터 생성 간격
    public float maxSpawnInterval = 5f; // 최대 몬스터 생성 간격

    private float spawnTimer = 0f;
    private float currentSpawnInterval = 0f;

    private void Start()
    {
        // 게임 시작 시 최초의 랜덤 생성 간격 설정
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnMonster();
            spawnTimer = 0f;

            // 다음 랜덤 생성 간격 설정
            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnMonster()
    {
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
