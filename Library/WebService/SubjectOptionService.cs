using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using DataService;

namespace WebService
{
    public class SubjectOptionService : ISubjectOptionService
    {
        private readonly IRepository<SubjectOption> _subjectOptionRepository;

        public SubjectOptionService(IRepository<SubjectOption> subjectOptionRepository)
        {
            _subjectOptionRepository = subjectOptionRepository;
        }
    }
}
