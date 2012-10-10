using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HangoverHunt;
namespace HangoverHunt.App.V1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Host _host;
        private void btnSubmitRiddle_Click(object sender, RoutedEventArgs e)
        {
           _host = new Host(new Riddle(txtHostQuestion.Text, txtHostAnswer.Text));
           txtPlayerQuestion.Text = _host.Riddle.Question;
        }

        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            bool correct = _host.Riddle.CheckAnswer(txtPlayerAnswer.Text);
            if (correct)
            {
                lblPlayerResult.Content = "Correct :)";
            }
            else
            {
                lblPlayerResult.Content = "Wrong :(";
            }
        }
    }
}
