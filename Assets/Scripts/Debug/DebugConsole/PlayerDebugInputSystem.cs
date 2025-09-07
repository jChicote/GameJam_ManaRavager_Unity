using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDebugInputSystem : MonoBehaviour
{

    #region <-------- Fields -------->

    public PlayerDebugHandler DebugHandler;
    public PlayerInput PlayerInput;

    private bool m_IsDebugConsoleActive;

    #endregion Fields

    #region <------- Event Handlers ------->

    private void OnDebug(InputValue value)
    {
        this.DebugHandler.ToggleDebugMenu();
        this.m_IsDebugConsoleActive = !this.m_IsDebugConsoleActive;
    }

    private void OnDebugSubmit(InputValue value)
        => this.DebugHandler.SubmitDebugCommand();

    #endregion Event Handlers

}