using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPos;
    [SerializeField] Transform targetPos;
    private ObjectPool pool;

    void Start()
    {
        pool = GameManager.Instance.pool;
    }

    void Update()
    {

    }
    public void SpawningEnemy()
    {
        foreach (var items in pool.pools)
        {
            for (int i = 0; i < items.size; i++)
            {
                GameObject enemyObj = pool.SpawnFromPool(items.tag);
                if (enemyObj != null)
                {
                    enemyObj.transform.position = spawnPos.position;
                    enemyObj.SetActive(true);

                    StartCoroutine(MoveToTargetPos(enemyObj));
                }
            }
        }
    }
    private IEnumerator MoveToTargetPos(GameObject enemyObj)
    {
        Enemy enemy = enemyObj.GetComponent<Enemy>();

        while (enemyObj != null && Vector2.Distance(enemyObj.transform.position, targetPos.position) > 0.1f)
        {
            if (enemy != null)
            {
                enemy.RunAnim(true);
            }

            enemyObj.transform.position = Vector2.MoveTowards(enemyObj.transform.position, targetPos.position, 2f * Time.deltaTime);
            yield return null;

            if (enemy != null)
            {
                enemy.RunAnim(false);
            }
        }
    }
}
