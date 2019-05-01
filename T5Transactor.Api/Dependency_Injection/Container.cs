using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace T5Transactor.Api.Dependency_Injection
{
    public class Container
    {
        // Create Container Object
        // public static ContainerBuilder builder;
        public static IContainer container;
        // Initialize Container Object
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            /// <summary>
            /// TODO: Every class has to be registered
            /// </summary>
            //Register your Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            // Presentation Layer class registry
            builder.RegisterType<Configuration.Settings>().As<Configuration.ISettings>();
            // Buisiness Layer class registry
            builder.RegisterType<Bll.BusinessTemplate.Class>().As<Bll.BusinessTemplate.IClass>();
            builder.RegisterType<Bll.BuildInformation.BuildData>().As<Bll.BuildInformation.IBuildData>();
            
            // Set the dependency resolve to be Autofac
            container = builder.Build();
            return container;
        }
        //public static void Initialize()
        //{
        //    // Instantiate Container Object
        //    builder = new ContainerBuilder();
        //    // Register Class Types for Container Object
        //    // TODO - These may need to be renamed to reflect current projects
        //    // Business, Service, and Data layers should be referenced below
        //    // Template to register type is :
        //    //      builder.RegisterType<CLASS_NAME>().As<INTERFACE_NAME>();
        //    builder.RegisterType<BusinessLogicLayer.BusinessTemplate.Class>().As<BusinessLogicLayer.BusinessTemplate.IClass>();
        //    builder.RegisterType<Controllers.BaseController>().As<Controllers.BaseController>();
        //    builder.RegisterType<Controllers.MainController>().As<Controllers.MainController>();
        //}
    }
}
