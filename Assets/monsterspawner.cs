using UnityEngine;

public class monsterspawner : MonoBehaviour
{
    public GameObject monsterPrefab; // 생성할 몬스터 프리팹
    public Transform leftSpawnPoint; // 왼쪽 스폰 지점
    public Transform rightSpawnPoint; // 오른쪽 스폰 지점
    public float spawnInterval = 5f; // 몬스터 생성 간격

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
        // 랜덤하게 왼쪽 또는 오른쪽 스폰 지점 선택
        Transform spawnPoint = Random.Range(0, 2) == 0 ? leftSpawnPoint : rightSpawnPoint;

        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
