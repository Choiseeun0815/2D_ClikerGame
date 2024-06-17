using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }
}