using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectPool pool;
    public EnemySpawner enemySpawner;

    // Stage 5-1 => 5�� currentStage, 1�� currentMiniState
    int currentStage = 1;
    int currentMiniState = 1;

    bool CanAutoAttack = false; //AutoAttack �������� �����ϸ� true�� ��ȯ

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
