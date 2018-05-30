using System;
using System.Collections.Generic;
using System.IO;
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

/*Да се направи игра тип „Сделка или не“.
Автоматично (и случайно разпределение на определени суми в кутиите).
 Да се направи елементарен алгоритъм за предложенията на банкера.*/

namespace DealNoDeal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            Game ng = new Game();
            ng.Show();
            ng.Start();
         
        }
        
       


    }
}
