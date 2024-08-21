using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public Vector3 SpawnPosition;
    public float SpawnTime;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var time = new WaitForSeconds(SpawnTime);

        while (true)
        {
            Instantiate(EnemyPrefab, SpawnPosition, Quaternion.identity);
            yield return time;
        }
    }
}
