using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] enemyWaves;
    public bool isFinished = false;

    private int currentWave = 0;

    void Start()
    {
        SpawnEnemyWave();
    }

    void SpawnEnemyWave()
    {
        var wave = enemyWaves[currentWave];

        Vector3 startPos = wave.flyPath[0];

        int count = wave.numberOfEnemy;

        // 👇 TÍNH OFFSET ĐỂ CÂN GIỮA
        Vector3 formationStartOffset = -(wave.formationOffset * (count - 1) / 2f);

       for (int i = 0; i < count; i++)
{
    Vector3 offset = formationStartOffset + (wave.formationOffset * i);
    Vector3 spawnPos = startPos + offset;

    var enemy = Instantiate(
        wave.enemyPrefab,
        spawnPos,
        Quaternion.identity
    );

    var agent = enemy.GetComponent<FlyPathAgent>();
    agent.flyPath = wave.flyPath;
    agent.flySpeed = wave.speed;

    // 👇 QUAN TRỌNG NHẤT (THIẾU CÁI NÀY)
    agent.offset = offset;
}

        currentWave++;

        if (currentWave < enemyWaves.Length)
        {
            Invoke(nameof(SpawnEnemyWave), wave.nextWaveDelay);
        }
        else
        {
            isFinished = true;
        }
    }
}