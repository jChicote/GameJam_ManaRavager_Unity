using UnityEngine;
using UnityEngine.Rendering;

public class PlayerDebugHandler : MonoBehaviour, IDebugHandler
{

    #region - - - - - - Methods - - - - - -

    public void SubmitDebugCommand()
    {
        if (DebugManager.Instance == null)
            return;

        DebugManager.Instance.EnterPressed();
    }

    public void ToggleDebugMenu()
    {
        if (DebugManager.Instance == null)
            return;

        DebugManager.Instance.ShowConsolePressed();
    }

    #endregion Methods

}