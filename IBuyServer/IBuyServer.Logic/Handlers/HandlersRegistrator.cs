using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Unity;

namespace IBuyServer.Logic.Handlers
{
    public static class HandlersRegistrator
    {
        public static void RegisterHandlers(UnityContainer container)
        {
            var requestHandlerType = typeof(IRequestHandler<,>);
            var handlers =
                Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Any(i => IsSubclassOfRawGeneric(requestHandlerType, i)));
            foreach (var handler in handlers)
            {
                var interfaces = handler.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    container.RegisterType(@interface, handler);
                }
            }
        }

        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var currentType = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == currentType)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }


}
