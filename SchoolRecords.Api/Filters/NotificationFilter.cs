using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SchoolRecords.Api.Common;
using SchoolRecords.Api.ViewModels;
using SchoolRecords.Shared.Notifications;
using System.Net;
using SchoolRecords.Domain.Entities;

namespace SchoolRecords.Api.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!_notificationContext.Succeeded || !context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var errors = new List<ErrorViewModel>();

                errors.AddRange(_notificationContext.Notifications.Select(not => new ErrorViewModel(not.Key, not.Message)));

                foreach (var key in context.ModelState.Keys)
                {
                    if (context.ModelState[key] != null)
                    {
                        foreach (var error in context.ModelState[key].Errors)
                        {
                            errors.Add(new ErrorViewModel(key, error.ErrorMessage));
                        }
                    }
                }

                var response = new CustomResponse<User>()
                {
                    Data = null,
                    Errors = errors
                };

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var json = JsonConvert.SerializeObject(response, serializerSettings);

                await context.HttpContext.Response.WriteAsync(json);

                return;
            }

            await next();
        }
    }
}
