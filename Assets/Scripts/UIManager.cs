
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StageTxt;

    private void Update()
    {
        if(GameManager.Instance != null)
            StageTxt.text = $"Stage {GameManager.Instance.currentStage}-{GameManager.Instance.currentMiniState}";
    }
}
