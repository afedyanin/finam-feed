namespace FinamFeed.CommandLine.Commands
{
    public interface ICommand
    {
        int Process();
        bool ValidateOptions();
    }
}
