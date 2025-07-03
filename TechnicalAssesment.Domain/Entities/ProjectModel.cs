using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssesment.Domain.Entities
{
    public class ProjectModel
    {
        public long? ProjectNumber { get; set; }
        public List<ActivityModel>? Activity { get; set; }
    }
}
