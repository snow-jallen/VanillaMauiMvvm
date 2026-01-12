using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using VanillaMaui.Models;

namespace VanillaMaui.PageModels
{
    public partial class MainPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(NameLength));
                Debug.WriteLine($"Name changed to: {name}");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int NameLength => string.IsNullOrEmpty(Name) ? 0 : Name.Length;
    }
}