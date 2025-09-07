public class DebugCommandBase
{

    #region - - - - - - Fields - - - - - -

    private string m_commandId;
    private string m_commandDescription;
    private string m_commandFormat;

    #endregion Fields

    #region - - - - - - Properties - - - - - -

    public string CommandId => m_commandId;
    public string CommandDescription => m_commandDescription;
    public string CommandFormat => m_commandFormat;

    #endregion Properties

    #region - - - - - - Constructors - - - - - -

    public DebugCommandBase(string commandId, string commandDescription, string commandFormat)
    {
        this.m_commandId = commandId;
        this.m_commandDescription = commandDescription;
        this.m_commandFormat = commandFormat;
    }

    #endregion Constructors

}