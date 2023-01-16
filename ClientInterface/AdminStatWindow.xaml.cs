using ClientInterface.MyService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для AdminStatWindow.xaml
    /// </summary>
    public partial class AdminStatWindow : Window
    {
        private MyService.MouseEventContractClient obj = new MouseEventContractClient();

        public AdminStatWindow()
        {
            InitializeComponent();

            var mainDataList = obj.GetUsersStatistic();
            dataGrid.ItemsSource = mainDataList;
        }
    }
}

