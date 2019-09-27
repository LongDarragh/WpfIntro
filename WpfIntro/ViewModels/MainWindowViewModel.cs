using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfIntro.Commands;
using WpfIntro.Models;

namespace WpfIntro.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string NameTextBlock { get; private set; }
        public string AgeTextBlock { get; private set; }
        public string AddressTextBlock { get; private set; }

        public string NameTextBox { get; set; }
        public string AgeTextBox { get; set; }
        public string AddressTextBox { get; set; }

        public ICommand ClearButtonCommand { get; private set; }
        public ICommand SaveButtonCommand { get; private set; }

        public string ClearButtonText { get; private set; }
        public string SaveButtonText { get; private set; }

        public MainWindowViewModel()
        {
            NameTextBlock = "Name";
            AgeTextBlock = "Age";
            AddressTextBlock = "Address";

            ClearButtonText = "Clear";
            SaveButtonText = "Save";

            NameTextBox = string.Empty;
            AgeTextBox = string.Empty;
            AddressTextBox = string.Empty;

            ClearButtonCommand = new RelayCommand(ClearButtonClick);
            SaveButtonCommand = new RelayCommand(SaveButtonClick);
        }

        private void SaveButtonClick()
        {
            Person person = new Person();

            if(string.IsNullOrWhiteSpace(NameTextBox) || string.IsNullOrWhiteSpace(AgeTextBox) || string.IsNullOrWhiteSpace(AddressTextBox))
            {
                MessageBox.Show("Please fill in all boxes");
                return;
            }

            person.Name = NameTextBox;
            person.Age = Convert.ToInt32(AgeTextBox);
            person.Address = AddressTextBox;

            if(person.Age < 0 || person.Age >100)
            {
                MessageBox.Show("Please enter an an age between 0 and 100");
                return;
            }

            MessageBox.Show($"{person.Name}\n{person.Age}\n{person.Address}");
        }

        private void ClearButtonClick()
        {
            NameTextBox = string.Empty;
            AgeTextBox = string.Empty;
            AddressTextBox = string.Empty;

            OnChanged(nameof(NameTextBox));
            OnChanged(nameof(AgeTextBox));
            OnChanged(nameof(AddressTextBox));

            MessageBox.Show("Clear Button Click");
        }
    }
}
