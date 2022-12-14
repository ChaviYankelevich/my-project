using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Middlewares
{
    public class TrackMiddleware
    {
        private readonly RequestDelegate _next;
        public TrackMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            var seq = Guid.NewGuid().ToString();
            context.Items.Add("ReqSeq", seq);
            await _next(context);
        }
    }
    public static class TrackMiddlewareExtension
    {
        public static IApplicationBuilder UseTrack(this IApplicationBuilder builder) 
        { 
        return builder.UseMiddleware<TrackMiddleware>();
        }
    }
}
