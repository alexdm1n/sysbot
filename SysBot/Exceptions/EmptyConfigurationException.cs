namespace SysBot.Exceptions;

[Serializable]
internal class EmptyConfigurationException : Exception
{
    public EmptyConfigurationException(string message)
        : base(message)
    {
    }

    public EmptyConfigurationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private EmptyConfigurationException()
    {
    }
}