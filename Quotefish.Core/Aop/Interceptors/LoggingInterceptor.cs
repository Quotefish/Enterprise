using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using log4net;

namespace Quotefish.Core.Aop.Interceptors
{
    public class LoggingInterceptor : ILoggingInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                ILog log = LogManager.GetLogger(invocation.InvocationTarget.GetType());
                log.Error(exception.Message, exception);

                throw;
            }
        }
    }
}
