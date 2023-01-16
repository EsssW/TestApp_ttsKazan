using ClientInterface.MyService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для UserStatWindow.xaml
    /// </summary>
    public partial class  UserStatWindow : Window
    {
        private MyService.MouseEventContractClient obj = new MouseEventContractClient();
        int _userId = 1;

        private List<UserStatistic> mainDataList;
        private string eventNameNow = "";

        public UserStatWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;

            mainDataList = obj.GetUserStatisticById(_userId).ToList();

            stopDateDT.SelectedDate = DateTime.Now;
            startDateDT.SelectedDate = DateTime.Now.AddDays(-1);

            dataGrid.ItemsSource = mainDataList;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eventType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // получаем название выбранного типа mouseEven
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            eventNameNow = selectedItem.Content.ToString();

            if(eventNameNow == "All")
            {
                dataGrid.ItemsSource = mainDataList;
                return;
            }

            // создаем Фильтрацию
            var _itemSourceList = new CollectionViewSource() { Source = mainDataList };
           _itemSourceList.Filter += new FilterEventHandler(FilterByEventName);
            ICollectionView Itemlist = _itemSourceList.View;

            dataGrid.ItemsSource = Itemlist;
        }

        private void FilterByEventName(object sender, FilterEventArgs e)
        {
            var obj = e.Item as UserStatistic;
            if (obj != null)
            {
                if (obj.EventTypeName.Contains(eventNameNow))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }
    }
}
