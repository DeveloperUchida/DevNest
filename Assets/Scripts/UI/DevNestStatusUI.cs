using TMPro;
using UnityEngine;

public class DevNestStatusUI : MonoBehaviour
{
    [SerializeField]
    private DevNestManager devNestManager;

    [SerializeField]
    private TMP_Text statusLabel;

    private void Start()
    {
        UpdateStatus(devNestManager.CurrentState);

        devNestManager.OnStateChanged += UpdateStatus;
    }

    private void OnDestroy()
    {
        if (devNestManager != null)
        {
            devNestManager.OnStateChanged -= UpdateStatus;
        }
    }

    private void UpdateStatus(DevNestManager.DevNestState state)
    {
        statusLabel.text = state switch
        {
            DevNestManager.DevNestState.Idle => "待機中",
            DevNestManager.DevNestState.Working => "作業中",
            DevNestManager.DevNestState.Break => "休憩中",
            _ => "不明"
        };
    }
}