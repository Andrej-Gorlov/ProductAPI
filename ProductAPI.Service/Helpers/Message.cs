namespace ProductAPI.Service.Helpers
{
    internal static class Message
    {
        public static string FilterAndSearch(bool isNull, string name, string filter, string? search = null)
        {
            string message = string.Empty;
            if (isNull)
            {
                WatchLogger.Log($"Список {name} пуст по фильтру: {filter}");
                message = $"Список {name} пуст по фильтру: {filter}";
                if (search != null)
                {
                    WatchLogger.Log($"и по поиску: {search}.");
                    message += $"и по поиску: {search}.";
                }
            }
            else
            {
                WatchLogger.Log($"Список {name} по фильтру: {filter}.");
                if (search != null)
                    WatchLogger.Log($"Список {name} по поиску: {search}.");
            }
            return message;
        }
    }
}
