using TechnicalAssignment.BusinessLogic.Implementation;
using TechnicalAssignment.BusinessLogic.Interface;
using TechnicalAssignment.Repository.Implementation;
using TechnicalAssignment.Repository.Interface;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;

namespace TechnicalAssignment.IoC
{
    public class SimpleInjectorIoCContainer
    {
        private static Container _container;

        public static Func<Container> Prepare(bool prepareState = true)
        {
            _container = new Container();

            _container.Register<ITransactionBusinessLogic, TransactionBusinessLogic>(Lifestyle.Singleton);
            _container.Register<ITransactionRepository, TransactionRepository>(Lifestyle.Singleton);
            if (prepareState)
                _container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            _container.Verify();

            // store the container for use by the application
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);

            return InitContainer;
        }

        private static Container InitContainer()
        {
            return _container;
        }
    }
}
