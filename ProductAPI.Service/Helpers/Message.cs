using DnsClient.Internal;
using Microsoft.Extensions.Logging;

namespace ProductAPI.Service.Helpers
{
    internal static class Message
    {
        public static string FilterAndSearch<T>(ILogger<T> logger, bool isNull, string name, string filter, string? search = null)
        {
            string message = string.Empty;
            if (isNull)
            {
                logger.LogInformation($"Список {name} пуст по фильтру: {filter}");
                message = $"Список {name} пуст по фильтру: {filter}";
                if (search != null)
                {
                    logger.LogInformation($"и по поиску: {search}.");
                    message += $"и по поиску: {search}.";
                }
            }
            else
            {
                logger.LogInformation($"Список {name} по фильтру: {filter}.");
                if (search != null)
                    logger.LogInformation($"Список {name} по поиску: {search}.");
            }
            return message;
        }
    }
}
