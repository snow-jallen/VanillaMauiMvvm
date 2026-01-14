using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
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
                AddToListCommand.NotifyCanExecuteChanged();
                Debug.WriteLine($"Name changed to: {name}");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int NameLength => string.IsNullOrEmpty(Name) ? 0 : Name.Length;

        private RelayCommand? addToListCommand;
        public RelayCommand AddToListCommand => addToListCommand ??= new RelayCommand(
            //execute
            () =>
            {
                Students.Add(new Student { Name = Name, Id = Students.Count + 1, Grade = 'A' });
                Name = string.Empty;
            },
            //can execute
            () => Name.Length > 3
        );
        

        public ObservableCollection<Student> Students { get; private set; } = new();
    }

    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public char Grade { get; set; }
    }
}