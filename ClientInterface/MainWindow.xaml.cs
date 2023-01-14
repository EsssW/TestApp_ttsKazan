using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Mous mous;
        private bool ActiveWrite = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void KeepReportMousePos(CancellationToken cancelToken)
        {
            //Создание и запуск Задачи для делагата
            Task.Factory.StartNew(() => 
            {
                while (!cancelToken.IsCancellationRequested) 
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

            mous.X = (ushort)p.X;
            mous.Y = (ushort)p.Y;

            info.Text = mous.msg;


        }

        private void Start_btn_Click(object sender, RoutedEventArgs e)
        {
            cts.Dispose(); // Очистка старого 
            cts = new CancellationTokenSource(); // "сброс"

            System.Drawing.Point p = System.Windows.Forms.Cursor.Position;

            mous = new Mous()
            {
                Id = 1,
                X = (ushort)p.X,
                Y = (ushort)p.Y
            };

            KeepReportMousePos(cts.Token);
        }

        private void Stop_btn_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                info.Text += "\n Клик левой ";
            if (e.ChangedButton == MouseButton.Right)
                info.Text += "\n Клик правой ";
            if (e.ChangedButton == MouseButton.Middle)
                info.Text += "\n Клик центральной ";
        }
    }
}
