using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace LightControl.Rpi
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string _message = "Starting..";

        private string ServerURI =
            "http://lightscontrol.azurewebsites.net/signalr";
        //"http://localhost:23790/signalr";

        private const int LED_PIN11 = 18;
        private GpioPin pin11;
        private GpioPinValue pinValue11;


        private const int LED_PIN8 = 17;
        private GpioPin pin8;
        private GpioPinValue pinValue8;

        private const int LED_PIN10 = 26;
        private GpioPin pin10;
        private GpioPinValue pinValue10;

        private const int LED_PIN9 = 22;
        private GpioPin pin9;
        private GpioPinValue pinValue9;


        private const int LED_PIN7 = 13;
        private GpioPin pin7;
        private GpioPinValue pinValue7;

        private const int LED_PIN6 = 16;
        private GpioPin pin6;
        private GpioPinValue pinValue6;

        private const int LED_PIN5 = 12;
        private GpioPin pin5;
        private GpioPinValue pinValue5;

        private const int LED_PIN4 = 25;
        private GpioPin pin4;
        private GpioPinValue pinValue4;

        private const int LED_PIN3 = 24;
        private GpioPin pin3;
        private GpioPinValue pinValue3;

        private const int LED_PIN2 = 23;
        private GpioPin pin2;
        private GpioPinValue pinValue2;

        private const int LED_PIN1 = 6;
        private GpioPin pin1;
        private GpioPinValue pinValue1;

        private const int LED_PIN12 = 5;
        private GpioPin pin12;
        private GpioPinValue pinValue12;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public HubConnection Connection { get; set; }
        public IHubProxy HubProxy { get; set; }

        public MainViewModel()
        {

            StartSignalRAsync();
        }

        private async Task StartSignalRAsync()
        {

            InitGPIO();

            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("LightHub");

            HubProxy.On<string, string>("AddMessage", OnData);

            try
            {
                await Connection.Start();

                Message = "Started..";
            }
            catch (HttpRequestException exception)
            {
                Message = "Unable to connect to server: Start server before connecting clients.";
            }
        }

        private void OnData(string messageName, string message)
        {
            //l1=true&l2=false&l3=true&l4=true&l5=false&l6=true&l7=true&l8=false
            var tabValues = message.Split('&');
            bool l1 = Convert.ToBoolean(tabValues[0].Replace("l1=", ""));
            bool l2 = Convert.ToBoolean(tabValues[1].Replace("l2=", ""));
            bool l3 = Convert.ToBoolean(tabValues[2].Replace("l3=", ""));
            bool l4 = Convert.ToBoolean(tabValues[3].Replace("l4=", ""));
            bool l5 = Convert.ToBoolean(tabValues[4].Replace("l5=", ""));
            bool l6 = Convert.ToBoolean(tabValues[5].Replace("l6=", ""));
            bool l7 = Convert.ToBoolean(tabValues[6].Replace("l7=", ""));
            bool l8 = Convert.ToBoolean(tabValues[7].Replace("l8=", ""));
            bool l9 = Convert.ToBoolean(tabValues[8].Replace("l9=", ""));
            bool l10 = Convert.ToBoolean(tabValues[9].Replace("l10=", ""));
            bool l11 = Convert.ToBoolean(tabValues[10].Replace("l11=", ""));
            bool l12 = Convert.ToBoolean(tabValues[11].Replace("l12=", ""));

            Debug.WriteLine($"{l1} \n {l2} \n {l3} \n {l4}");

            if (l1)
            {
                pinValue1 = GpioPinValue.High;
                pin1.Write(pinValue1);
            }
            else
            {
                pinValue1 = GpioPinValue.Low;
                pin1.Write(pinValue1);
            }

            if (l2)
            {
                pinValue2 = GpioPinValue.High;
                pin2.Write(pinValue2);
            }
            else
            {
                pinValue2 = GpioPinValue.Low;
                pin2.Write(pinValue2);
            }

            if (l3)
            {
                pinValue3 = GpioPinValue.High;
                pin3.Write(pinValue3);
            }
            else
            {
                pinValue3 = GpioPinValue.Low;
                pin3.Write(pinValue3);
            }
            if (l4)
            {
                pinValue4 = GpioPinValue.High;
                pin4.Write(pinValue4);
            }
            else
            {
                pinValue4 = GpioPinValue.Low;
                pin4.Write(pinValue4);
            }

            if (l5)
            {
                pinValue5 = GpioPinValue.High;
                pin5.Write(pinValue5);
            }
            else
            {
                pinValue5 = GpioPinValue.Low;
                pin5.Write(pinValue5);
            }

            if (l6)
            {
                pinValue6 = GpioPinValue.High;
                pin6.Write(pinValue6);
            }
            else
            {
                pinValue6 = GpioPinValue.Low;
                pin6.Write(pinValue6);
            }
            if (l7)
            {
                pinValue7 = GpioPinValue.High;
                pin7.Write(pinValue7);
            }
            else
            {
                pinValue7 = GpioPinValue.Low;
                pin7.Write(pinValue7);
            }

            if (l8)
            {
                pinValue8 = GpioPinValue.High;
                pin8.Write(pinValue8);
            }
            else
            {
                pinValue8 = GpioPinValue.Low;
                pin8.Write(pinValue8);
            }

            if (l9)
            {
                pinValue9 = GpioPinValue.High;
                pin9.Write(pinValue9);
            }
            else
            {
                pinValue9 = GpioPinValue.Low;
                pin9.Write(pinValue9);
            }

            if (l10)
            {
                pinValue10 = GpioPinValue.High;
                pin10.Write(pinValue10);
            }
            else
            {
                pinValue10 = GpioPinValue.Low;
                pin10.Write(pinValue10);
            }

            if (l11)
            {
                pinValue11 = GpioPinValue.High;
                pin11.Write(pinValue11);
            }
            else
            {
                pinValue11 = GpioPinValue.Low;
                pin11.Write(pinValue11);
            }

            if (l12)
            {
                pinValue12 = GpioPinValue.High;
                pin12.Write(pinValue12);
            }
            else
            {
                pinValue12 = GpioPinValue.Low;
                pin12.Write(pinValue12);
            }

            //if (pinValue2 == GpioPinValue.High)
            //{
            //    pinValue2 = GpioPinValue.Low;
            //    pin2.Write(pinValue2);
            //}
            //else
            //{
            //    pinValue2 = GpioPinValue.High;
            //    pin2.Write(pinValue2);
            //}
        }

        private void Connection_Closed()
        {

        }

        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin12 = null;
                pin1 = null;
                pin2 = null;
                pin4 = null;
                pin3 = null;
                pin5 = null;
                pin6 = null;
                pin7 = null;
                pin8 = null;
                pin9 = null;
                pin10 = null;
                pin11 = null;

                return;
            }

            pin12 = gpio.OpenPin(LED_PIN12);
            pinValue12 = GpioPinValue.High;
            pin12.Write(pinValue12);
            pin12.SetDriveMode(GpioPinDriveMode.Output);

            pin1 = gpio.OpenPin(LED_PIN1);
            pinValue1 = GpioPinValue.High;
            pin1.Write(pinValue1);
            pin1.SetDriveMode(GpioPinDriveMode.Output);

            pin2 = gpio.OpenPin(LED_PIN2);
            pinValue2 = GpioPinValue.High;
            pin2.Write(pinValue2);
            pin2.SetDriveMode(GpioPinDriveMode.Output);

            pin3 = gpio.OpenPin(LED_PIN3);
            pinValue3 = GpioPinValue.High;
            pin3.Write(pinValue3);
            pin3.SetDriveMode(GpioPinDriveMode.Output);

            pin4 = gpio.OpenPin(LED_PIN4);
            pinValue4 = GpioPinValue.High;
            pin4.Write(pinValue4);
            pin4.SetDriveMode(GpioPinDriveMode.Output);

            pin5 = gpio.OpenPin(LED_PIN5);
            pinValue5 = GpioPinValue.High;
            pin5.Write(pinValue5);
            pin5.SetDriveMode(GpioPinDriveMode.Output);

            pin6 = gpio.OpenPin(LED_PIN6);
            pinValue6 = GpioPinValue.High;
            pin6.Write(pinValue6);
            pin6.SetDriveMode(GpioPinDriveMode.Output);

            pin7 = gpio.OpenPin(LED_PIN7);
            pinValue7 = GpioPinValue.High;
            pin7.Write(pinValue7);
            pin7.SetDriveMode(GpioPinDriveMode.Output);

            pin8 = gpio.OpenPin(LED_PIN8);
            pinValue8 = GpioPinValue.High;
            pin8.Write(pinValue8);
            pin8.SetDriveMode(GpioPinDriveMode.Output);

            pin9 = gpio.OpenPin(LED_PIN9);
            pinValue9 = GpioPinValue.High;
            pin9.Write(pinValue9);
            pin9.SetDriveMode(GpioPinDriveMode.Output);

            pin10 = gpio.OpenPin(LED_PIN10);
            pinValue10 = GpioPinValue.High;
            pin10.Write(pinValue10);
            pin10.SetDriveMode(GpioPinDriveMode.Output);


            pin11 = gpio.OpenPin(LED_PIN11);
            pinValue11 = GpioPinValue.High;
            pin11.Write(pinValue11);
            pin11.SetDriveMode(GpioPinDriveMode.Output);



        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
