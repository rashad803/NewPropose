using StructureMap;
using NewPropose.DataAccess.IRepository;
using NewPropose.DataAccess.Repository;
using NewPropose.DataAccess;
namespace NewPropose {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
           
                            x.For<IDatabaseFactory>().HttpContextScoped().Use<DatabaseFactory>();
                            x.For<IUnitOfWork>().HttpContextScoped().Use<UnitOfWork>();

                            x.For<IEmployeeRepository>().HttpContextScoped().Use<EmployeeRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}