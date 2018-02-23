namespace Cerseil.Commands
{
    public class CommandValidationResult : ICommandValidationResult
    {
        public CommandValidationResult()
        {
        }

        public CommandValidationResult(string errorMessage)
            : this(null, errorMessage)
        {
        }

        public CommandValidationResult(string memeberName, string errorMessage)
        {
            MemberName = memeberName;
            ErrorMessage = errorMessage;
        }

        public string MemberName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
