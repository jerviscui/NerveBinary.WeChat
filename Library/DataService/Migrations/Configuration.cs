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
                Title = "2016年最能代表你的一个字？",
                ResultTitle = "的2016关键字是",
                Description = "2015年就要接近尾声了，你会以什么样的字来迎接2016年呢?",
                AdditionNum = 1000,
                Options = new List<SubjectOption>()
                {
                    new SubjectOption()
                    {
                        Content = "『快』", ContentExt = "你的办事效率快速，也跟着影响周围人的目标前进！", Order = 0, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "『性』", ContentExt = "人之初，性本色，这一年你的精力异常旺盛，并且充满了魅力，桃花盛开。", Order = 1, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "『猛』", ContentExt = "你就像一个猛将、为了将来更好而累计努力的一年。", Order = 3, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "『食』", ContentExt = "所以2016年你的生活会围绕着“食”展开，究竟是要吃还是要减肥成为你这一年的重大考验。", Order = 4, ResultType = 1
                    },
                },
                Picture = new Picture() { Url = path + "01.jpg", FileName = "01.jpg", FileType = "jpg" },
                ResultPicture = new Picture() { Url = path + "02.jpg", FileName = "02.jpg", FileType = "jpg" },
                Order = 1,
            };

            var subject2 = new SubjectInfo()
            {
                Title = "你的身体构造是？",
                Description = "快来测一测你的身体是怎样的构造！",
                ResultTitle = "的身体构造竟然是",
                AdditionNum = 2000,
                Options = new List<SubjectOption>()
                {
                    new SubjectOption()
                    {
                        Content = "头- 伴侣基本靠想", Order = 0, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "头 - 想要睡", Order = 1, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "头 - 穆里尼奥", Order = 2, ResultType = 1
                    },
                    new SubjectOption()
                    {
                        Content = "嘴- 通讯基本靠吼", Order = 0, ResultType = 2
                    },
                    new SubjectOption()
                    {
                        Content = "嘴 - 想要吃", Order = 1, ResultType = 2
                    },
                    new SubjectOption()
                    {
                        Content = "嘴 - 苏亚雷斯", Order = 2, ResultType = 2
                    },
                    new SubjectOption()
                    {
                        Content = "心- 取暖基本靠抖", Order = 0, ResultType = 3
                    },
                    new SubjectOption()
                    {
                        Content = "心 - 想要爱", Order = 1, ResultType = 3
                    },
                    new SubjectOption()
                    {
                        Content = "心 - 梅西", Order = 2, ResultType = 3
                    },
                    new SubjectOption()
                    {
                        Content = "手- 夜生活基本靠手", Order = 0, ResultType = 4
                    },
                    new SubjectOption()
                    {
                        Content = "手 - 想要打字", Order = 1, ResultType = 4
                    },
                    new SubjectOption()
                    {
                        Content = "手 - 诺伊尔", Order = 2, ResultType = 4
                    },
                    new SubjectOption()
                    {
                        Content = "腿- 交通基本靠走", Order = 0, ResultType = 5
                    },
                    new SubjectOption()
                    {
                        Content = "腿 - 想要停止", Order = 1, ResultType = 5
                    },
                    new SubjectOption()
                    {
                        Content = "脚 - C罗", Order = 2, ResultType = 5
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
