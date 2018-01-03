using System.Threading.Tasks;
using Microsoft.Owin;
using System.Text;
using Owin;

namespace Rico.S01.SimapleOwinMiddleware2
{
    public class CustomMiddleware : OwinMiddleware
    {
        CustomMiddlewareParameters _parameter;

        protected CustomMiddleware(OwinMiddleware next, CustomMiddlewareParameters parameter) : base(next)
        {
            _parameter = parameter;

        }

        public override Task Invoke(IOwinContext context)
        {
            if (Next != null)
            {
                var msg = Encoding.UTF8.GetBytes(_parameter.ABC);
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.WriteAsync(msg);
                //处理操作
                return Next.Invoke(context);
            }
            return Task.FromResult<int>(0);

        }
    }
    public class CustomMiddlewareParameters
    {

        public string ABC { get; set; }

    }
    public static class CustomMiddlewareExtentions
    {
        public static IAppBuilder UseLYMMiddleware(this IAppBuilder builder)
        {
            return builder.Use<CustomMiddleware>(new CustomMiddlewareParameters { ABC = "这是测试" });

        }


    }
}