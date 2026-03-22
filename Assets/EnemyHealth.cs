using UnityEngine;

public class EnemyHealth : Health
{
    public static int LivingEnemyCount = 0;

    private void OnEnable()
    {
        LivingEnemyCount++;
    }

    private void OnDisable()
    {
        LivingEnemyCount--;
    }
}