public class DebugCommandConfigurator
{

    #region - - - - - - Fields - - - - - -

    private DebugManager m_DebugManager;

    #endregion Fields

    #region - - - - - - Constructors - - - - - -

    public DebugCommandConfigurator()
        => this.m_DebugManager = DebugManager.Instance;

    #endregion Constructors

    #region - - - - - - Methods - - - - - -

    public void ConfigureCommands()
    {
        new Debug_PlayerMetricRandomizer().RegisterCommand(m_DebugManager);
    }

    #endregion Methods

}