using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssesment.Domain.Entities
{
    public class LogEntryModel
    {
        public UserInformationModel? UserInformation { get; set; }
        public DateTime? Time { get; set; }
        public string? Note { get; set; }
        public string? Duration { get; set; }
    }
}
