using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Task_24.DAL;

namespace Task_24.BLL.Infrastructure {

    public class ServiceModule : NinjectModule {

        private readonly string _connectionString;
        public ServiceModule(string connection) {
            _connectionString = connection;
        }
        public override void Load() {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
