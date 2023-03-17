namespace Shop.Aggregator.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Une erreur s'est produite");
            }
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive =  true
            });
        }
    }
}
