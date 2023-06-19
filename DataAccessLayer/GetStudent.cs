using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP_Ui
{
    public class GetStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentCode { get; set; }
        public string NationalCode { get; set; }
        public string Profile { get; set; } 
        public string Payeh { get; set; }
        public string Reshteh { get; set; }
        public string BimaryKhas { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhoneNumber { get; set; }
        public string FatherName { get; set; }
        public string FatherJob { get; set; }
        public string FatherMobile { get; set; }
        public string MotherJob { get; set; }
        public string MotherMobile { get; set; }
        public bool LeftParent { get; set; }
        public string DeadParent { get; set; }
        public string BimaryKhasParent { get; set; }
        public string Other { get; set; }
        public byte Score { get; set; }
    }
}
