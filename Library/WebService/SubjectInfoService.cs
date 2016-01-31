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
    public class SubjectInfoService : ISubjectInfoService
    {
        private readonly IRepository<SubjectInfo> _subjectInfoRepository;
        private readonly IRepository<Picture> _pictuRepository;

        public SubjectInfoService(IRepository<SubjectInfo> subjectInfoRepository, IRepository<Picture> pictuRepository)
        {
            _subjectInfoRepository = subjectInfoRepository;
            _pictuRepository = pictuRepository;
        }

        public IList<SubjectInfo> GetList(int count)
        {
            return _subjectInfoRepository.Table.Where(o => o.IsValid).OrderByDescending(o => o.Order).Take(count).ToList();
        }

        public IPagedList<SubjectInfo> GetList(int pageIndex, int pageSize)
        {
            var query = _subjectInfoRepository.Table.Where(o => o.IsValid);
            query = query.OrderByDescending(o => o.Order);
            
            return new PagedList<SubjectInfo>(query, pageIndex, pageSize);
        }

        public SubjectInfo GetSubjectById(int subjectId)
        {
            return _subjectInfoRepository.Table.FirstOrDefault(o => o.IsValid && o.Id == subjectId);
        }

        public void Delete(int subjectId)
        {
            var subject = _subjectInfoRepository.Table.FirstOrDefault(o => o.Id == subjectId);
            if (subject != null)
            {
                _pictuRepository.Delete(subject.Picture);
                _pictuRepository.Delete(subject.ResultPicture);

                _subjectInfoRepository.Delete(subject);
            }
        }
    }
}
