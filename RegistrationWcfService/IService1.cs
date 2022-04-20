using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace RegistrationWcfService
{
   
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InsertStudDetails(StudDetails stud);
        [OperationContract]
        DataSet GetStudDetails(StudDetails stud);
        [OperationContract]
        DataSet FetchUpdatedRecords(StudDetails stud);
        [OperationContract]
        string UpdateStudDetails(StudDetails stud);
        [OperationContract]
        bool DeleteStudDetails(StudDetails stud);
        [OperationContract]
        bool CheckLogin(StudDetails stud);

    }



    [DataContract]
    public class StudDetails
    {
        [DataMember]
        public int Studid { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public string Studaddress { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Course { get; set; }
        [DataMember]
        public string Sports { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Emailaddress { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
