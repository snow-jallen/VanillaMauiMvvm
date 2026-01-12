using VanillaMaui.Models;
using VanillaMaui.PageModels;

namespace VanillaMaui.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}