using System.Threading.Tasks;

namespace neo.pcl
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
