using System.Collections.Generic;
using System.ServiceModel;
using TestApp.DB;

namespace TestApp
{
    [ServiceContract]
    public interface IMouseEventContract
    {
        /// <summary>
        /// Test Contract
        /// </summary>
        [OperationContract]
        void StartRecording(int userId);

        [OperationContract]
        void StopRecording(int userId);

        [OperationContract]
        bool GetRecordingStatus();

        /// <summary>
        /// MousEvent Contract
        /// </summary>
        [OperationContract]
        List<MousEvent> GetMousEvents();

        [OperationContract]
        MousEvent GetMousEventById(int id);

        [OperationContract]
        void AddNewMousEvent(MousEvent mousEvent);

        [OperationContract]
        bool RemoveMousEvent(MousEvent mousEvent);

        [OperationContract]
        bool UpdateMousEvent(int id, MousEvent mousEvent);

        /// <summary>
        /// User Contract
        /// </summary>
        [OperationContract]
        int GetMyMousEventCount(int id);

        [OperationContract]
        int SignIn(string login, string password);

        [OperationContract]
        bool Registration(ServerUser user);

        [OperationContract]
        bool IsAdmin(int id);

        [OperationContract]
        bool SendEmail(int userId,string msg);

        [OperationContract]
        bool SendSms(int userId,string msg);

        [OperationContract]
        List<AllUsersStatistic> GetUsersStatistic();

        [OperationContract]
        List<UserStatistic> GetUserStatisticById(int userId);
    }
}
