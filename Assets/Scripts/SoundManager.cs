using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip attackSound1;
    public AudioClip attackSound2;

    public AudioClip UpgradeStatSound;

    public AudioClip EnemyDieSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //���� ��ȯ�Ǿ bgm�� ��� ����� �� �ֵ��� 
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
