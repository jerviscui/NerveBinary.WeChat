using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace WebService
{
    public interface ISubjectOptionService
    {
        IPagedList<SubjectOption> GetOptions(int subjectId, int pageIndex, int pageSize);

        void UpdateOption(SubjectOption model);

        SubjectOption GetOptionById(int optionId);

        void Hide(SubjectOption model);

        void CreateOption(SubjectOption model);
    }
}
