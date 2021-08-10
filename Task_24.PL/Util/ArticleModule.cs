using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Task_24.BLL.Interfaces;
using Task_24.BLL.Services;

namespace Task_24.PL.Util {
    public class ArticleModule : NinjectModule {

        public override void Load() {
            Bind<IArticleService>().To<ArticleService>();
        }
    }
}