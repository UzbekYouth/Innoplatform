using Innoplatform.Domain.Entities.Users;
using Innoplatform.Service.DTOs.Users;
using Innoplatform.Service.Interfaces.IOTPServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.Services.OTPServices
{
    public class SendSmsToGraduatedUserService : ISendSmsToGraduatedUserService
    {
        private readonly HttpClient _httpClient;

        public SendSmsToGraduatedUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendSmsToAllUsersAsync()
        {
            try
            {
                // Assuming you have a method to get all user details
                var allUserDetails = await GetAllUserDetailsAsync();

                // API endpoint for sending SMS
                var apiUrl = "https://notify.eskiz.uz/api/message/sms/send";

                foreach (var userDetails in allUserDetails)
                {
                    // Prepare data for the request
                    var requestData = new
                    {
                        mobile_phone = userDetails.PhoneNumber,
                        message = $"Assalomu alekum {userDetails.FirstName} {userDetails.LastName}, biz sizga o`z startuplaringizga sarmoya kiritishda yordam bera oladigan yagona platformamiz. Loyihangizni yuklang va sarmoyalarga ega bo`ling!",
                        from = "4546", // Change to your nickname (as a string)
                    };

                    // Serialize the data to JSON
                    var jsonContent = JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    // Add Bearer Token to Authorization header
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDU5NTk0NzcsImlhdCI6MTcwMzM2NzQ3Nywicm9sZSI6InRlc3QiLCJzdWIiOiI1OTkyIn0.LbdcCseN6MtGVFVkG_owmDzm8k-2Uuj6FXg5mJEvGoA");

                    // Make the POST request
                    var response = await _httpClient.PostAsync(apiUrl, content);

                    // Check if the request was successful
                    if (!response.IsSuccessStatusCode)
                    {
                        // Log or handle the error if needed
                        Console.WriteLine($"Failed to send SMS to {userDetails.FirstName} {userDetails.LastName} ({userDetails.PhoneNumber}). Status code: {response.StatusCode}");
                    }
                }

                // All SMS sent successfully
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception if needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<List<UserDetails>> GetAllUserDetailsAsync()
        {
            var apiUrl = "https://localhost:7113/api/Users";

            try
            {
                var response = await _httpClient.GetStringAsync(apiUrl);

                // Deserialize JSON response to a dynamic object
                var responseObject = JsonConvert.DeserializeAnonymousType(response, new { statusCode = 0, data = new List<User>() });

                if (responseObject.statusCode == 200)
                {
                    // Extract phone numbers and user details from the list of users
                    var userDetailsList = new List<UserDetails>();
                    foreach (var user in responseObject.data)
                    {
                        userDetailsList.Add(new UserDetails
                        {
                            PhoneNumber = user.PhoneNumber,
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        });
                    }

                    return userDetailsList;
                }
                else
                {
                    Console.WriteLine($"API request failed with status code: {responseObject.statusCode}");
                    return new List<UserDetails>(); // or throw an exception if needed
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<UserDetails>(); // or throw an exception if needed
            }
        }
    }

    public class UserDetails
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Add other properties as needed
    }
}
