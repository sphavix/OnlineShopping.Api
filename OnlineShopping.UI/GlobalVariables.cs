namespace OnlineShopping.UI
{
    public static class GlobalVariables
    {
        public static HttpClient client = new HttpClient();

        static GlobalVariables()
        {
            client.BaseAddress = new Uri("https://localhost:7231/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
