using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssesment.Domain.Entities;

namespace TechnicalAssesment.Infrastructure
{
    public class AppStateService
    {
        public UserInformationModel? UserInformation;
        public List<ProjectModel>? Projects;
    }
}
