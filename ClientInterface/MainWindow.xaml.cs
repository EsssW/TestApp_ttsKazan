using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void KeepReportMousePos()
        {
            //Создание и запуск Задачи для делагата
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    // выполнение делегата Синхронно
                    this.Dispatcher.Invoke(
                        DispatcherPriority.Render, // приоритет: отрисовка (7)
                        new Action(() =>
                        {
                            GetCursorPos();
                        }));
                }
            });
        }
        public void GetCursorPos()
        {
            // получение позиции курсора (с использованеим WinForms методов)
            System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
            // вывод в TextBox
            mous_pos_tb.Text = p.X + " " + p.Y;
        }

        private void Start_btn_Click(object sender, RoutedEventArgs e)
        {
            KeepReportMousePos();
        }

        private void Stop_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
