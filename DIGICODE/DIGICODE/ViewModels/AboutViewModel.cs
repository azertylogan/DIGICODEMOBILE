using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace DIGICODE.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "A propos de la M2L";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://google.fr")));
        }

        public ICommand OpenWebCommand { get; }
    }
}