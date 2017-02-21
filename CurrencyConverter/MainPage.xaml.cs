using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CurrencyConverter
{

    public sealed partial class MainPage : Page
    {
        public int fromCurrency, toCurrency, x; // list indexes
        public double amount1, amount2; // money to convert amount

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(400, 450);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            currencyList.Items.Add(new Item("USD", 0));
            currencyList.Items.Add(new Item("EUR", 1));
            currencyList.Items.Add(new Item("GBP", 2));
            currencyList.Items.Add(new Item("PLN", 3));
            currencyList2.Items.Add(new Item("USD", 0));
            currencyList2.Items.Add(new Item("EUR", 1));
            currencyList2.Items.Add(new Item("GBP", 2));
            currencyList2.Items.Add(new Item("PLN", 3));
            Clear();
        }

        private void currencyList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item itm = (Item)currencyList.SelectedItem;
            toCurrency = currencyList2.SelectedIndex;
            currencyAmount2.Text = Calculate().ToString();
        }

        private void currencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item itm2 = (Item)currencyList2.SelectedItem;
            fromCurrency = currencyList.SelectedIndex;
            currencyAmount2.Text = Calculate().ToString();
        }

        private void currencyAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (currencyAmount.Text.All(Char.IsDigit) && (!string.IsNullOrEmpty(currencyAmount.Text)) && (!(currencyAmount.Text == ".")))
            {
                amount1 = Convert.ToDouble(currencyAmount.Text);
                currencyAmount2.Text = Calculate().ToString();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void reverseButton_Click(object sender, RoutedEventArgs e)
        {
            x = currencyList.SelectedIndex;
            currencyList.SelectedIndex = currencyList2.SelectedIndex;
            currencyList2.SelectedIndex = x;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        class Item //comboBox
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }

        public double Calculate()
        {
            if (fromCurrency == 0)
            {
                switch (toCurrency)
                {
                    case 0: amount2 = amount1; break;
                    case 1: amount2 = amount1 * 0.948901646; break;
                    case 2: amount2 = amount1 * 0.805217811; break;
                    case 3: amount2 = amount1 * 4.08585192; break;
                }
            }
            else if (fromCurrency == 1)
            {
                switch (toCurrency)
                {
                    case 0: amount2 = amount1 * 1.05385; break;
                    case 1: amount2 = amount1; break;
                    case 2: amount2 = amount1 * 0.848578791; break;
                    case 3: amount2 = amount1 * 4.30587505; break;
                }
            }
            else if (fromCurrency == 2)
            {
                switch (toCurrency)
                {
                    case 0: amount2 = amount1 * 1.17844095; break;
                    case 1: amount2 = amount1 * 1.2419; break;
                    case 2: amount2 = amount1; break;
                    case 3: amount2 = amount1 * 5.0742195; break;
                }
            }
            else if (fromCurrency == 3)
                switch (toCurrency)
                {
                    case 0: amount2 = amount1 * 0.244747; break;
                    case 1: amount2 = amount1 * 0.232240831; break;
                    case 2: amount2 = amount1; break;
                    case 3: amount2 = amount1 * 0.197074644; break;
                }
            return amount2;
        }

        public void Clear()
        {
            currencyList.SelectedIndex = 0;
            currencyList2.SelectedIndex = 0;
            currencyAmount.Text = "";
            currencyAmount2.Text = "";
        }
    }
}
