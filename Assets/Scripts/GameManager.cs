using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   
    public ObjectPool pool;

    public EnemySpawner enemySpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();

        if(enemySpawner != null )
            enemySpawner.SpawningEnemy();
    }
}
