using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DevNestManager : MonoBehaviour
{
    private bool _interlized;
    public enum DevNestState
    {
        Idle,
        Working,
        Break
    }
    public DevNestState CurrentState { get; private set; }

    public event Action<DevNestState> OnStateChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("🏠 DevNest started!");
        ChangeState(DevNestState.Idle); // 初期ステータス
    }

    public void ChangeState(DevNestState newState)
    {
        //同じ状態なら何もしない
        if (_interlized && CurrentState == newState)
            return;
        CurrentState = newState;
        _interlized = true;
        Debug.Log($"🏠 DevNest State: {CurrentState}"); //現在のユーザーのステータス表示
        OnStateChanged ?.Invoke(CurrentState);
    }
    // Update is called once per frame
    /// <summary>
    ///　操作キーの説明
    /// 1番キーは”待機”
    /// 2番キーは"作業"
    /// 3番キーは"休憩"
    /// </summary>
    void Update()
    {
        if (Keyboard.current == null)
            return;
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ChangeState(DevNestState.Idle);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ChangeState(DevNestState.Working);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ChangeState(DevNestState.Break);
        }

    }
}
