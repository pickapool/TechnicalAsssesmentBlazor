using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssesment.Domain
{
    public class Enums
    {
        public enum ActivityType
        {
            [Description("Phone Interview")]
            PhoneInterview,
            Recruitment,
            [Description("Project Management")]
            ProjectManagement,
            [Description("Data Cleaning")]
            DataCleaning
        }
    }
}
