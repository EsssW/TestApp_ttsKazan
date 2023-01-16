# TestApp_ttsKazan
## Тестовое задание на позицию C# разработчика в ТензоТехСервис Казань 2023

**Краткое название**: Клиент-серверное приложение для записи в БД координат указателя мыши и событий клика мышью

Стек используемых технологий: `WCF`, `WPF`, `EF Core`, `SQLite`

**Техническое задание:**
---
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

## Запуск приложения
---
1. Запуск Host.exe (TestApp\Host\bin\Debug\Host.exe)
![image](https://user-images.githubusercontent.com/43808999/212757862-14334216-03fc-4df9-8bc3-0e0f4305d50a.png)

2. Запус Client (TestApp\ClientInterface\bin\Debug\ClientInterface.exe)

## Скриншоты работы приложения
---

| Окно регистрации  | Окно авторизации |
| ------------- | ------------- |
| ![image](https://user-images.githubusercontent.com/43808999/212758033-65d4c3ba-b151-4cdf-b418-c49bbd254e2a.png)  | ![image](https://user-images.githubusercontent.com/43808999/212757919-996e42be-4ee6-4d62-bc6c-c48c994302ec.png)  |
---
**Главное окно**
| При входе  | Запись начата | Запись остановлена |
| ------------- | ------------- | ------------- |
| ![image](https://user-images.githubusercontent.com/43808999/212758461-9558f7c3-4d0d-41a1-bd12-40055c0fe8ad.png)  | ![image](https://user-images.githubusercontent.com/43808999/212759005-dbf80603-7c7e-40da-b04e-0432f46270a0.png)  | ![image](https://user-images.githubusercontent.com/43808999/212759039-7d83d0c5-2c21-4eed-aef2-f58125271a02.png) |
---
| Статистика пользователя  | Статистика пользователя с фильтром | Статистика для администратора |
| ------------- | ------------- | ------------- |
| ![image](https://user-images.githubusercontent.com/43808999/212759677-afd8ad88-d9ed-4306-8c33-96abd92789ba.png)|  ![image](https://user-images.githubusercontent.com/43808999/212759754-7326e4d6-8dc5-4ad1-8244-2ef299beade2.png)| ![image](https://user-images.githubusercontent.com/43808999/212760205-5e1f9f31-6a08-4a46-abce-36032ba1fcc1.png) |
---

**Отправка письма пользователю при достижении 50и сообщений**
![image](https://user-images.githubusercontent.com/43808999/212760491-84e9893b-7ce5-4091-bf26-9c00df7e3687.png)
---

Для отправки/получения письма использовался сервис [ethereal.email](https://ethereal.email/)

И Библиотека [MailKit](https://github.com/jstedfast/MailKit)


