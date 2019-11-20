using SimpleInjector;
using System;
using System.Threading;

namespace TechnicalAssignment.Utils
{
    public static class ObjectFactory
    {
        private static Lazy<Container> _containerBuilder;

        public static Container Container
        {
            get { return _containerBuilder.Value; }
        }

        public static void Initialize(Func<Container> container)
        {
            _containerBuilder = new Lazy<Container>(container, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        public static T GetInstance<T>() where T : class
        {
            return Container.GetInstance<T>();
        }
    }
}
