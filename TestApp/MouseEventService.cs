
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.DB;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace TestApp
{
    public class MouseEventService : IMouseEventContract
    {
        dbContext db = new dbContext();

        private bool recordingIsStart;

        public bool RecordingIsStart
        {
            get { return recordingIsStart; }
            set
            {
                recordingIsStart = value;
            }
        }

        #region MousEvent Controller Region
        public async void AddNewMousEvent(MousEvent mousEvent)
        {
            db.MousEvent.Add(mousEvent);
            await db.SaveChangesAsync();
            Console.WriteLine($"{DateTime.Now}  |  User: {mousEvent.UserId} new MouseEvent");

        }

        public List<MousEvent> GetMousEvents()
        {
            using (var dataContext = new dbContext())
            {
                return dataContext.MousEvent.ToList();
            }
        }

        public MousEvent GetMousEventById(int id)
        {
            return db.MousEvent.Find(id);
        }

        public int GetMyMousEventCount(int id)
        {
            return db.MousEvent
                .Where(e => e.UserId == id)
                .Count();
        }

        public bool RemoveMousEvent(MousEvent mousEvent)
        {
            

            var _mousEvent = db.MousEvent.Find(mousEvent.Id);

            if (_mousEvent != null)
            {
                db.MousEvent.Remove(_mousEvent);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateMousEvent(int id, MousEvent mousEvent)
        {
            var _mousEvent = db.MousEvent.Find(id);

            if (_mousEvent != null)
            {
                _mousEvent.mousX_pos = mousEvent.mousX_pos;
                _mousEvent.mousY_pos = mousEvent.mousY_pos;
                _mousEvent.eventName = mousEvent.eventName;
                _mousEvent.UserId = mousEvent.UserId;
                db.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

        #region User Controller Region
        public bool IsAdmin(int id)
        {
            return db.ServerUser
            .Any(u => u.Id == id && u.IsAdmin == 1);
        }

        public int SignIn(string login, string password)
        {
            try
            {
                var user = db.ServerUser
                   .FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    Console.WriteLine($"{DateTime.Now}  |  {user.Login} Is Login");
                    return user.Id;
                }
                Console.WriteLine($"{db.ServerUser.ToList().Count} юзеров в бд");

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
            
        }

        public bool Registration(ServerUser user)
        {
            try
            {
                db.ServerUser.Add(user);
                db.SaveChanges();

                Console.WriteLine($"{DateTime.Now}  |  {user.Login}  Register");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<AllUsersStatistic> GetUsersStatistic()
        {
            var query = db.ServerUser
                .Select(x => new AllUsersStatistic()
                {
                    userId = x.Id,
                    userName = x.Name,
                    userEventsCount = x.mousEvents.Count()
                });

            return query.ToList();
        }
        public List<UserStatistic> GetUserStatisticById(int userId)
        {
            var query = db.MousEvent.Where(u => u.UserId == userId)
                .Select(x => new UserStatistic()
                {
                    dateTime = x.eventTime,
                    EventTypeName = x.eventName,
                    mousX_pos = x.mousX_pos ?? 0,
                    mousY_pos = x.mousY_pos ?? 0,
                });

            return query.ToList();
        }

        #endregion

        #region SendMessage Region
        public bool SendEmail(int userId, string msg)
        {
            var reciverEmail = db.ServerUser.Find(userId).Email;
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ryann.boyer62@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(reciverEmail));
            email.Subject = "MousEvetnServer Subject";
            email.Body = new TextPart("plain")
            {
                Text = msg + $"{DateTime.Now}"
            };

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("ryann.boyer62@ethereal.email", "HxJSbN5M7khgABBsWb");
                client.Send(email);
                client.Disconnect(true);
                Console.WriteLine($"{DateTime.Now}  |  Sended email --{msg}--  To  {reciverEmail}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public bool SendSms(int userId,string msg)
        {
            throw new NotImplementedException();
        }
        #endregion


        public void StartRecording(int userId)
        {
            this.RecordingIsStart = true;
            Console.WriteLine($"{DateTime.Now}  |  userLogin Is Start Recording");
        }

        public void StopRecording(int userId)
        {
            this.RecordingIsStart = false;
            Console.WriteLine($"{DateTime.Now}  |  userLogin Is Stop Recording");
        }

        public bool GetRecordingStatus()
        {
            return recordingIsStart;
        }

    }
}
