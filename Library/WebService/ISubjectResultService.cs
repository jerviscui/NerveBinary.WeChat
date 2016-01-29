using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace WebService
{
    public interface ISubjectResultService
    {
        int GetResultCount(int subjectId);

        void Add(SubjectResult model);

        SubjectResult GetResultByKey(int subjectId, string key);
    }
}
