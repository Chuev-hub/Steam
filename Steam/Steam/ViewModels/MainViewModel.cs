using Steam.Infrastructure;
using Steam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Steam.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<Car> cars { get; set; } = new ObservableCollection<Car>();
        Car selectedCar;
        public Car SelectedCar
        {
            get
            {
                return selectedCar;
            }
            set
            {
                selectedCar = value;
                Notify();
            }
        }
        public MainViewModel()
        {
            InitCommands();
            cars.Add(new Car() { Title = "Title", Mark = "Mark", Photo = "https://specials-images.forbesimg.com/imageserve/5d3703e2f1176b00089761a6/960x0.jpg?cropX1=836&cropX2=5396&cropY1=799&cropY2=3364" });
            cars.Add(new Car() { Title = "Title2", Mark = "Mark2", Photo = "https://specials-images.forbesimg.com/imageserve/5d3703e2f1176b00089761a6/960x0.jpg?cropX1=836&cropX2=5396&cropY1=799&cropY2=3364" });
            cars.Add(new Car() { Title = "Title3", Mark = "Mark3", Photo = "https://specials-images.forbesimg.com/imageserve/5d3703e2f1176b00089761a6/960x0.jpg?cropX1=836&cropX2=5396&cropY1=799&cropY2=3364" });
        }
        public void InitCommands()
        {
            ClickCommand = new RelayCommand(x =>
            {

            });

        }
        public ICommand ClickCommand { get; private set; }
    }
}
