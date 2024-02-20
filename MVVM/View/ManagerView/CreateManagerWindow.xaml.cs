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

namespace SoftTradeTEST.MVVM.View.ManagerView
{
    /// <summary>
    /// Interaction logic for CreateManagerWindow.xaml
    /// </summary>
    public partial class CreateManagerWindow : Window
    {
        private IUnit _unit= new Unit(new AppDbConetext.Context()); 
        public CreateManagerWindow()
        {
            InitializeComponent();
        }
        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (Name_textBox.Text.IsNullOrEmpty())
                    throw new NullReferenceException();

                Manager manager = new Manager()
                {
                    Name = Name_textBox.Text
                };
                _unit.Manager.Add(manager);
                _unit.Save();
                this.Close();

            }
            catch(NullReferenceException) 
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
