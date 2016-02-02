using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace DataService.Map
{
    public class SubjectResultMap : BaseMap<SubjectResult>
    {
        public SubjectResultMap()
            : base("SubjectResult")
        {
            this.HasRequired(o => o.Subject).WithMany().HasForeignKey(o => o.SubjectId);
            this.HasRequired(o => o.ResultPicture).WithMany().HasForeignKey(o => o.ResultPictureId).WillCascadeOnDelete(false);
            this.HasMany(o => o.Options).WithMany().Map(configuration =>
                configuration.ToTable("ResultOptionMapping").MapLeftKey("ResultId").MapRightKey("OptionId"));

            this.Property(o => o.Key).IsRequired().HasMaxLength(10).IsVariableLength();
            this.Property(o => o.CreateOnUtc).IsRequired();
        }
    }
}
