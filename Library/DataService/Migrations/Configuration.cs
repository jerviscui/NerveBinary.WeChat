using System.Collections.Generic;
using Core.Domain;

namespace DataService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataService.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataService.EFDbContext";
        }

        protected override void Seed(DataService.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            string path = "/Upload/Game/";

            var subject = new SubjectInfo()
            {
                Title = "2016�����ܴ������һ���֣�",
                ResultTitle = "��2016�ؼ�����",
                Description = "2015���Ҫ�ӽ�β���ˣ������ʲô��������ӭ��2016����?",
                AdditionNum = 1000,
                Options = new List<SubjectOption>()
                {
                    new SubjectOption()
                    {
                        Content = "���졻", ContentExt = "��İ���Ч�ʿ��٣�Ҳ����Ӱ����Χ�˵�Ŀ��ǰ����", Order = 0, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "���ԡ�", ContentExt = "��֮�����Ա�ɫ����һ����ľ����쳣��ʢ�����ҳ������������һ�ʢ����", Order = 1, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "���͡�", ContentExt = "�����һ���ͽ���Ϊ�˽������ö��ۼ�Ŭ����һ�ꡣ", Order = 3, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "��ʳ��", ContentExt = "����2016����������Χ���š�ʳ��չ����������Ҫ�Ի���Ҫ���ʳ�Ϊ����һ����ش��顣", Order = 4, ResultType = 1
                    },
                },
                Picture = new Picture() { Url = path + "01.jpg", FileName = "01.jpg", FileType = "jpg" },
                ResultPicture = new Picture() { Url = path + "02.jpg", FileName = "02.jpg", FileType = "jpg" },
                Order = 1,
            };

            var subject2 = new SubjectInfo()
            {
                Title = "������幹���ǣ�",
                Description = "������һ����������������Ĺ��죡",
                ResultTitle = "�����幹�쾹Ȼ��",
                AdditionNum = 2000,
                Options = new List<SubjectOption>()
                {
                    new SubjectOption()
                    {
                        Content = "ͷ- ���»�������", Order = 0, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "ͷ - ��Ҫ˯", Order = 1, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "ͷ - �������", Order = 2, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "��- ͨѶ��������", Order = 0, ResultType = 2
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ��Ҫ��", Order = 1, ResultType = 2
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ������˹", Order = 2, ResultType = 2
                    },
                    new SubjectOption()
                    {
                        Content = "��- ȡů��������", Order = 0, ResultType = 3
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ��Ҫ��", Order = 1, ResultType = 3
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ÷��", Order = 2, ResultType = 3
                    },
                    new SubjectOption()
                    {
                        Content = "��- ҹ�����������", Order = 0, ResultType = 4
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ��Ҫ����", Order = 1, ResultType = 4
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ŵ����", Order = 2, ResultType = 4
                    },
                    new SubjectOption()
                    {
                        Content = "��- ��ͨ��������", Order = 0, ResultType = 5
                    },
                    new SubjectOption()
                    {
                        Content = "�� - ��Ҫֹͣ", Order = 1, ResultType = 5
                    },
                    new SubjectOption()
                    {
                        Content = "�� - C��", Order = 2, ResultType = 5
                    },
                },
                Picture = new Picture() { Url = path + "03.jpg", FileName = "03.jpg", FileType = "jpg" },
                ResultPicture = new Picture() { Url = path + "04.jpg", FileName = "04.jpg", FileType = "jpg" },
                Order = 2,
            };

            context.Set<SubjectInfo>().AddOrUpdate(info => info.Title, subject, subject2);
            
            context.SaveChanges();
        }
    }
}
