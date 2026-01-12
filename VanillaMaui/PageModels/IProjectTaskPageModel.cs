using CommunityToolkit.Mvvm.Input;
using VanillaMaui.Models;

namespace VanillaMaui.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}