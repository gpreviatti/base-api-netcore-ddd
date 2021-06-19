using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Controllers
{
    public abstract class DefaultController<T> : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        private readonly ILogger<T> _logger;

        public DefaultController(IServiceProvider serviceProvider, ILogger<T> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void LoggingExceptions(Exception exception) =>
            _logger.LogError(exception: exception.InnerException, message: exception.Message);

        protected void LoggingWarning(string message) => _logger.LogWarning(message);

        protected S GetService<S>() => _serviceProvider.GetService<S>();
    }
}
