# TestApp_ttsKazan
**Тестовое задание на позицию C# разработчика в ТензоТехСервис Казань 2023**

**Краткое название**: Клиент-серверное приложение для записи в БД координат указателя мыши и событий клика мышью

Стек используемых технологий: `WCF`, `WPF`, `EF Core`, `SQLite`

**Техническое задание:**

Разработать клиент-серверное приложение для записи значений координат указателя мыши относительно экрана с сохранением в БД при изменении 
координаты на 10 пикселей по любой из осей, либо нажатии клавиш мыши.

Добавить сохранение даты/времени и описания события(сдвиг, клик правой, левой или средней).

При запуске программы выводится таблица(дата/время, событие, координаты), ввести фильтр по дате/времени и событию.

Запись в БД начинать после нажатия кнопки запуск/стоп.

Предусмотреть аутентификацию админ и пользователь.

В клиенте отображается счетчик с количеством записей событий.

Каждые 50 записей программа отправляет сообщение(почта, скайп, ватсап, контакт, смс  и тд- любые 2 варианта) с подтверждением от пользователя
на условный адрес(записанный в БД без возможности изменения в программе) с указанием количества записей.

Сервер запускать консолью с логированием основных событий: 
подключение к БД , 
аутентификация,	
запуск/остановка записи 

Другие элементы интерфейса на Ваше усмотрение. 
Проект необходимо выполнять на C# в MS Visual Studio с использованием SQLite.
Приоритетный стек технологий: WCF, WPF.