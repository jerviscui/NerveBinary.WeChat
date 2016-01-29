using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService.Map
{
    public class SubjectInfoMap : BaseMap<SubjectInfo>
    {
        public SubjectInfoMap()
            : base("SubjectInfo")
        {
            this.HasRequired(o => o.Picture).WithMany().HasForeignKey(o => o.PictureId).WillCascadeOnDelete(false);
            this.HasRequired(o => o.ResultPicture).WithMany().HasForeignKey(o => o.ResultPictureId).WillCascadeOnDelete(false);
            this.HasMany(o => o.Options).WithRequired(option => option.Subject).HasForeignKey(option => option.SubjectId);

            this.Property(o => o.Title).IsRequired();
            this.Property(o => o.ResultTitle).IsOptional();
            this.Property(o => o.Description).IsRequired();
        }
    }
}
