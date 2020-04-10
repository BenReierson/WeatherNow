using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNow.ViewModels;
using Xamarin.Forms;

namespace WeatherNow.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public MainPage(MainViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
