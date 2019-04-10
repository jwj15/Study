using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        public class Car
        {
            public int speed { get; set; }
            public string type {get; set;}
        }
        public Page2()
        {
            InitializeComponent();

            List<Car> cars = new List<Car>();
            Random r = new Random();
            for(int i = 0; i < 8; i++)
            {
                Car car = new Car();
                car.speed = r.Next(0, 200);
                int tempNum = r.Next(1, 3);
                string carType = null;
                switch(tempNum)
                {
                    case 1: carType = "트럭";
                        break;
                    case 2: carType = "승용차";
                        break;
                    case 3: carType = "오토바이";
                        break;
                }
                car.type = carType;
                cars.Add(car);
            }
            
            this.DataContext = cars;


        }
    }
}
