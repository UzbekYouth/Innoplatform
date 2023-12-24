using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Innoplatform.Service.Interfaces.IOTPServices;
using Newtonsoft.Json;

namespace Innoplatform.Service.DTOs.OTP.Sms
{
    public class SmsService : ISmsService
    {
        private readonly HttpClient _httpClient;

        public SmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendAsync(Message message)
        {
            try
            {
                //There is an api url tahseen.uz/users
                //Do the logic that I can get all users PhoneNumber and send One message to everyone
                
                // API endpoint for sending SMS
                var apiUrl = "https://notify.eskiz.uz/api/message/sms/send";

                // Prepare data for the request
                var requestData = new
                {
                    mobile_phone = message.PhoneNumber,
                    message = message.MessageContent,
                    from = "4546", // Change to your nickname (as a string)
                };

                // Serialize the data to JSON
                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Add Bearer Token to Authorization header
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDU5OTAxOTUsImlhdCI6MTcwMzM5ODE5NSwicm9sZSI6InRlc3QiLCJzdWIiOiI1OTk4In0.OW0wQl1-kbjYPBi3Kc_xtbqRU8phk1erzvD816AYg0M");

                // Make the POST request
                var response = await _httpClient.PostAsync(apiUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // SMS sent successfully
                    return true;
                }

                // Log or handle the error if needed
                Console.WriteLine($"Failed to send SMS. Status code: {response.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                // Log or handle the exception if needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
