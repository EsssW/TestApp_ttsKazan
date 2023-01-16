using ClientInterface.MyService;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Brushes = System.Windows.Media.Brushes;

namespace ClientInterface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // переменная для отправки и получения состояния задачи
        private CancellationTokenSource cts = new CancellationTokenSource();
        // переменая для работы с сервисом
        public MyService.MouseEventContractClient obj = new MouseEventContractClient();
        private Mous mous = new Mous(); // переменная для сохранения состояния мыши
        private bool mousChekIsActive = false; // состояние Записи (начата/не начата)
        
        public MainWindow() { }

        public MainWindow(int userId )
        {
            InitializeComponent();
            mous.UserId = userId; // Для глобальной переменной задаем UserId для дальнейщей работы
            eventCount_Tb.Text = obj.GetMyMousEventCount(userId).ToString(); // выводим количество записей данного пользователя
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

            // получение обновленного числа записей
            int mouseEventsCount = obj.GetMyMousEventCount(mous.UserId);
            eventCount_Tb.Text = mouseEventsCount.ToString();
            // если кол-во записей кратно 50и отправляем письмо пользователю
            if (mouseEventsCount % 50 == 0)
            {
                obj.SendEmail(mous.UserId, $"Вы сделали еще 50 действий мышью.\nОбщее количество действий ={mouseEventsCount}");
            }
        }

        private void Start_btn_Click(object sender, RoutedEventArgs e)
        {
            
            // исключение возможности нажать "Старт" если запись уже начата
            if (mousChekIsActive == true)
                return;

            //Вызов на сервере метода для лоигрования начала записи клиента
            //В качестве параметра передается id текущего клиента
            obj.StartRecording(mous.UserId);

            mousChekIsActive = true; // запись начата
            cts.Dispose(); // Очистка старого токена
            cts = new CancellationTokenSource(); // "сброс"

            workGridText_TB.Text = "Запись Начата";
            workGrid.Background = Brushes.Green;

            KeepReportMousePos(cts.Token);
        }

        private void Stop_btn_Click(object sender, RoutedEventArgs e)
        {
            // исключение возможности нажать "Стоп" если запись еще на начата
            if (mousChekIsActive == false)
                return;

            obj.StopRecording(mous.UserId);
            mousChekIsActive = false; // запись окончена
            workGridText_TB.Text = "Запись Остановлена";
            workGrid.Background = Brushes.LightGray;
            cts.Cancel();
        }

        // Событие нажатия кнопки мыши на рабочей области
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // если запись не начала, то следющий код выполнять не нужно
            if (mousChekIsActive == false)
                return;

            // получение текущей позици мыши
            System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
            mous.X = (ushort)p.X;
            mous.Y = (ushort)p.Y;

            // Определение какая кнопка мыши была нажата и запись события клика в бд
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    mous.ChangeMousEventType(MousEventType.LeftClick);
                    break;

                case MouseButton.Right:
                    mous.ChangeMousEventType(MousEventType.RightClick);
                    break;

                case MouseButton.Middle:
                    mous.ChangeMousEventType(MousEventType.MidleClick);
                    break;
            }
        }

        private void userStat_Btn_Click(object sender, RoutedEventArgs e)
        {
            var userStatWind = new UserStatWindow(mous.UserId);
            userStatWind.Show();

            if (obj.IsAdmin(mous.UserId))
            {
                var adminStatWind = new AdminStatWindow();
                adminStatWind.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            obj.StopRecording(mous.UserId);
        }
    }
}
