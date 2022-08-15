using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpleRestClient
{
    internal static class RequestHandler
    {
        internal static async Task<string> GetRequest(string requestUri, string auth = null)
        {
            HttpClient client = new()
            {
                Timeout = TimeSpan.FromSeconds(30),
            };
            string result = null;
            try
            {
                HttpResponseMessage message = await client.GetAsync(requestUri);
                try
                {
                    result = JArray.Parse(await message.Content.ReadAsStringAsync()).ToString();

                }
                catch (JsonReaderException)
                {
                    result = await message.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                App.alertService.ShowAlert("Error processing request", $"{ex.Message}");
            }
            client.Dispose();
            return result ?? string.Empty;
        }
    }
}
