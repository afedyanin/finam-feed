namespace FinamFeed.CommandLine.Commands
{
    using System.Threading.Tasks;

    public interface ICommand
    {
        Task Process();
        bool ValidateOptions();
        string GetUsage();
    }
}
