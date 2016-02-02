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
    public class SubjectResultService : ISubjectResultService
    {
        private readonly IRepository<SubjectResult> _subjectResultRepository;

        public SubjectResultService(IRepository<SubjectResult> subjectResultRepository)
        {
            _subjectResultRepository = subjectResultRepository;
        }

        public int GetResultCount(int subjectId)
        {
            return _subjectResultRepository.Table.Count(o => o.IsValid && o.SubjectId == subjectId);
        }

        public void Add(SubjectResult model)
        {
            _subjectResultRepository.Add(model);
        }

        public SubjectResult GetResultByKey(int subjectId, string key)
        {
            return _subjectResultRepository.Table.FirstOrDefault(o => o.SubjectId == subjectId && o.Key.Equals(key) && o.IsValid);
        }

        public IPagedList<SubjectResult> GetResults(int subjectId, int pageIndex, int pageSize)
        {
            var query = _subjectResultRepository.Table.Where(o => o.SubjectId == subjectId && o.IsValid);
            query = query.OrderByDescending(o => o.CreateOnUtc);

            return new PagedList<SubjectResult>(query, pageIndex, pageSize);
        } 
    }
}
