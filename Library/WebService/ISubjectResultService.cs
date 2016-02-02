using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace WebService
{
    public interface ISubjectResultService
    {
        int GetResultCount(int subjectId);

        void Add(SubjectResult model);

        SubjectResult GetResultByKey(int subjectId, string key);

        IPagedList<SubjectResult> GetResults(int subjectId, int pageIndex, int pageSize);
    }
}
