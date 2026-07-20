using System.Net;
using System.Text.Json;
namespace Logistics.Api.Middleware;
using Logistics.Application.Exceptions;

public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            context.Response.StatusCode = 400;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    Message = exception.Message
                });

            return;
        }
        catch (TruckNotFoundException exception)
        {
            context.Response.StatusCode = 404;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    Message = exception.Message
                });

            return;
        }
        catch (PalletNotFoundException exception)
        {
            context.Response.StatusCode = 404;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    Message = exception.Message
                });

            return;
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    Message = exception.Message
                });
        }

    }
}