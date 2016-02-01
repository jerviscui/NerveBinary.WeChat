using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace WebService
{
    public interface ISubjectInfoService
    {
        IList<SubjectInfo> GetList(int count);

        IPagedList<SubjectInfo> GetList(int pageIndex, int pageSize);

        SubjectInfo GetSubjectById(int subjectId);

        void Hide(int subjectId);
    }
}
