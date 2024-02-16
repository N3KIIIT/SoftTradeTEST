using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
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
using System.Windows.Shapes;

namespace SoftTradeTEST.MVVM.View
{
    /// <summary>
    /// Interaction logic for EditManagerWindow.xaml
    /// </summary>
    public partial class EditManagerWindow : Window
    {
        private Manager _selectedManager = new Manager();
        private IUnit _unit = new Unit();
        public EditManagerWindow()
        {
            InitializeComponent();
        }
        public EditManagerWindow(int id)
        {
            InitializeComponent();
            _selectedManager = _unit.Manager.Get(id);
            Name_textBox.Text = _selectedManager.Name;
        }

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name_textBox.Text == null)
                    throw new NullReferenceException();

                _selectedManager.Name = Name_textBox.Text;
                _unit.Manager.Update(_selectedManager);
                this.Close();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
