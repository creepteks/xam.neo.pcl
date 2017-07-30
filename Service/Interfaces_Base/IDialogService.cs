using System.Threading.Tasks;

namespace Tag.Core
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
