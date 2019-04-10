using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2
{
    class CurrencyConverterViewModel2 : Notifier
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

        private decimal converted;

        public decimal Converted
        {
            get { return converted; }
            set
            {
                this.converted = value;
                OnPropertyChanged("Converted");
            }
        }

        private Currency selectedCurrency;

        public Currency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                this.selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
                OnSelectedCurrencyChanged();
            }
        }

        private IEnumerable<Currency> currencies;

        public IEnumerable<Currency> Currencies
        {
            get { return currencies; }
            set
            {
                this.currencies = value;
                OnPropertyChanged("Currencies");
            }
        }

        private string resultText;

        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                OnPropertyChanged("ResultText");
            }
        }

        public CurrencyConverterViewModel2()
        {
            Currencies = new Currency[] {
                new Currency("US Dollar", 1.1M),
                new Currency("Baitish Pound", 0.9M)
            };
        }

        private void OnEurosChanged()
        {
            ComputeConverted();
        }

        private void OnSelectedCurrencyChanged()
        {
            ComputeConverted();
        }

        private void ComputeConverted()
        {
            if (SelectedCurrency == null)
            {
                return;
            }

            Converted = Euros * SelectedCurrency.Rate;
            ResultText = string.Format(
                "Amount in {0}", SelectedCurrency.Title);
        }
    }
}
