using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAttackController controller;
    private void Start()
    {
        controller = GetComponent<PlayerAttackController>();
    }
}