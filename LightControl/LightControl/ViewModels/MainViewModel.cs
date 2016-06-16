using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LightControl.Models;
using Plugin.RestClient;
using Xamarin.Forms;

namespace LightControl.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _message = "Not Started..";
        private Lamps _lamps = new Lamps();

        public Lamps Lamps
        {
            get { return _lamps; }
            set
            {
                _lamps = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public Command SendLightCommand
        {
            get
            {
                return new Command(SendLight);
            }
        }

        private async void SendLight()
        {
            var restClient = new RestClient<string>();
            var lampsUrlParameter = $"l1={_lamps.Lamp1}&l2=" +
                                    $"{_lamps.Lamp2}&l3=" +
                                    $"{_lamps.Lamp3}&l4=" +
                                    $"{_lamps.Lamp4}&l5=" +
                                    $"{_lamps.Lamp5}&l6=" +
                                    $"{_lamps.Lamp6}&l7=" +
                                    $"{_lamps.Lamp7}&l8=" +
                                    $"{_lamps.Lamp8}&l9=" +
                                    $"{_lamps.Lamp9}&l10=" +
                                    $"{_lamps.Lamp10}&l11=" +
                                    $"{_lamps.Lamp11}&l12=" +
                                    $"{_lamps.Lamp12}";

            var isSuccessful = await restClient.GetAsync(lampsUrlParameter);

            Message = isSuccessful.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
