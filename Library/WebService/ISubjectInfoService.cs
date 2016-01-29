using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace WebService
{
    public interface ISubjectInfoService
    {
        IList<SubjectInfo> GetList(int count);

        SubjectInfo GetSubjectById(int subjectId);
    }
}
