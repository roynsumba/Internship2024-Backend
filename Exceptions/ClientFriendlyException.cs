namespace AppraisalTracker.Exceptions
{
    public class ClientFriendlyException : Exception
    {
        /// <inheritdoc />
        public ClientFriendlyException(string message) : base(message)
        {
        }
    }
}
