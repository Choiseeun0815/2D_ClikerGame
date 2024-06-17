
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StageTxt;
    [SerializeField] private TextMeshProUGUI GoldTxt;

    private void Update()
    {
        if(GameManager.Instance != null)
        {
            StageTxt.text = $"Stage {GameManager.Instance.currentStage}-{GameManager.Instance.currentMiniState}";
            GoldTxt.text = $"GOLD : {GameManager.Instance.Gold} G";

        }
    }
}
