namespace CustomerApi.Services
{
    public static class ProfileService
    {


        public static  async Task<string> GenerateProfileImage(string fullName)
        {
            // Format the API URL
            string apiUrl = $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(fullName)}&format=svg";

            using (var httpClient = new HttpClient())
            {
                // Call the API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the URL from the response
                    string imageUrl = await response.Content.ReadAsStringAsync();
                    return imageUrl;
                }
                else
                {
                    // Handle API call failure
                    throw new Exception($"Failed to generate profile image. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
