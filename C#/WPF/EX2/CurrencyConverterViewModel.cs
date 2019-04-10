using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class CurrencyConverterViewModel : Notifier
    {
        private decimal euros;

        public decimal Euros
        {
            get { return euros; }
            set
            {
                this.euros = value;
                OnPropertyChanged("Euros");
                OnEurosChanged();
            }
        }

        private decimal dollars;

        public decimal Dollars
        {
            get { return dollars; }
            set
            {
                this.dollars = value;
                OnPropertyChanged("Dollars");
            }
        }

        private void OnEurosChanged()
        {
            Dollars = Euros * 1.1M;
        }
    }
}
