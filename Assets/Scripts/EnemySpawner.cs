using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public Transform spawnPos;
    [SerializeField] public Transform targetPos;


    void Update()
    {

    }
    public void SpawningEnemy()
    {
        foreach (var items in GameManager.Instance.pool.pools)
        {
            for (int i = 0; i < items.size; i++)
            {
                GameObject enemyObj = GameManager.Instance.pool.SpawnFromPool(items.tag);
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

            enemyObj.transform.position = Vector2.MoveTowards(enemyObj.transform.position, targetPos.position, 4f * Time.deltaTime);
            yield return null;

            if (enemy != null)
            {
                enemy.RunAnim(false);
            }
        }
    }
}
