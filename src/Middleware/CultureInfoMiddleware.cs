using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CDNConverter.API.Middleware
{
    public class CultureInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestedCulture = context.Request.Headers["Accept-Language"];

            var cultureInfo = new CultureInfo("en");

            if (string.IsNullOrWhiteSpace(requestedCulture) == false && supportedLanguages.Any(c => c.Name.Equals(requestedCulture)))
            {
                cultureInfo = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
