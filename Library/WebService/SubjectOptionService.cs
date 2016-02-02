using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
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

        public IPagedList<SubjectOption> GetOptions(int subjectId, int pageIndex, int pageSize)
        {
            var query = _subjectOptionRepository.Table.Where(o => o.SubjectId == subjectId && o.IsValid);
            query = query.OrderBy(o => o.ResultType).ThenByDescending(o => o.Order);

            return new PagedList<SubjectOption>(query, pageIndex, pageSize);
        }

        public void UpdateOption(SubjectOption model)
        {
            _subjectOptionRepository.Update(model);
        }

        public SubjectOption GetOptionById(int optionId)
        {
            return _subjectOptionRepository.Table.FirstOrDefault(o => o.Id == optionId && o.IsValid);
        }

        public void Hide(SubjectOption model)
        {
            _subjectOptionRepository.Hide(model);
        }

        public void CreateOption(SubjectOption model)
        {
            _subjectOptionRepository.Add(model);
        }
    }
}
