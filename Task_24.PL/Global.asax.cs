using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Task_24.BLL.Infrastructure;
using Task_24.PL.Util;

namespace Task_24.PL {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

            // Dependency injection
            var articleModule = new ArticleModule();
            var newsModule = new NewsModule();
            var answerModule = new AnswerModule();
            var commentModule = new CommentModule();
            var authorModule = new AuthorModule();
            var genreModule = new GenreModule();

            var serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(
                articleModule,
                newsModule,
                answerModule,
                commentModule,
                authorModule,
                genreModule, 
                serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
