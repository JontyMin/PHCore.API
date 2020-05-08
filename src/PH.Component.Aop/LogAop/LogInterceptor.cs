using Castle.DynamicProxy;

namespace PH.Component.Aop.LogAop
{
    public class LogInterceptor : IInterceptor
    {
        private readonly LogInterceptorAsync _logInterceptorAsync;

        public LogInterceptor(LogInterceptorAsync logInterceptorAsync)
        {
            _logInterceptorAsync = logInterceptorAsync;
        }

        public void Intercept(IInvocation invocation)
        {
            _logInterceptorAsync.ToInterceptor().Intercept(invocation);
        }
    }
}
