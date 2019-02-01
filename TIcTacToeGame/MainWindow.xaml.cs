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

namespace TIcTacToeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// //Group 6: Joe Huang, Ny Lee, Sonam Sonam, Chaitany Virothi, Harpreet Kaur
    public partial class MainWindow : Window
    {
        TicTacToeVM tvm = new TicTacToeVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = tvm;          
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {     
            tvm.CreatePanel();
            tvm.ValidatePanel();
            tvm.DisplayPanel();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            tvm.Reset();
        }
    }
}
