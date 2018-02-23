namespace Cerseil.Commands
{
    public interface ICommandValidationResult
    {
        string MemberName { get; set; }

        string ErrorMessage { get; set; }
    }
}
