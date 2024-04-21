using RestSharp;
using RestSharp.Authenticators;
using StorySpoilerRestSharpTests.Models;
using System.Net;
using System.Text.Json;

namespace StorySpoilerRestSharpTests
{
    public class StorySpoilerTests
    {
        private RestClient client;
        private const string BASEURL = "https://d5wfqm7y6yb3q.cloudfront.net";
        private static string storyId;

        [OneTimeSetUp]
        public void Setup()
        {
            string accessToken = GetJwtToken("alex357", "qaz123");

            var options = new RestClientOptions(BASEURL)
            {
                Authenticator = new JwtAuthenticator(accessToken)
            };

            client = new RestClient(options);
        }

        private string GetJwtToken(string userName, string password)
        {
            RestClient authClient = new RestClient(BASEURL);
            var request = new RestRequest("/api/User/Authentication");
            request.AddJsonBody(new
            {
                userName,
                password
            });

            var response = authClient.Execute(request, Method.Post);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = JsonSerializer.Deserialize<JsonElement>(response.Content);
                var token = content.GetProperty("accessToken").GetString();
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new InvalidOperationException("Access Token is null or empty");
                }
                return token;
            }
            else
            {
                throw new InvalidOperationException($"Unexpected response type {response.StatusCode} with data {response.Content}");
            }
        }

        [Test, Order(1)]
        public void CreateNewStory_WithCorrectData_ShouldSucceed()
        {
            var requestData = new StoryDTO()
            {
                Title = "Test story",
                Description = "Test story description",
                Url = "https://st2.depositphotos.com/1105977/5461/i/380/depositphotos_54615585-stock-photo-old-books-on-wooden-table.jpg"
            };

            var request = new RestRequest("/api/Story/Create");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Post);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(responseData.Msg, Is.EqualTo("Successfully created!"));

            storyId = responseData.StoryId;
        }

        [Test, Order(2)]
        public void EditStory_WithCorrectData_ShouldSucceed()
        {
            var requestData = new StoryDTO()
            {
                Title = "Edited test title",
                Description = "Test description with edits",
                Url = "https://st2.depositphotos.com/1105977/5461/i/380/depositphotos_54615585-stock-photo-old-books-on-wooden-table.jpg"
            };

            var request = new RestRequest($"/api/Story/Edit/{storyId}");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Put);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseData.Msg, Is.EqualTo("Successfully edited"));
        }

        [Test, Order(3)]
        public void DeleteStory_WithCorrectId_ShouldSucceed()
        {
            var request = new RestRequest($"/api/Story/Delete/{storyId}");

            var response = client.Execute(request, Method.Delete);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("Deleted successfully!"));
        }

        [Test, Order(4)]
        public void CreateNewStory_WithIncorrectData_ShouldFaild()
        {
            var requestData = new StoryDTO()
            {
                
            };

            var request = new RestRequest("/api/Story/Create");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Post);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test, Order(5)]
        public void EditStory_WithIncorrectData_ShouldSucceed()
        {
            var requestData = new StoryDTO()
            {
                Title = "Edited test title wit incorrect storyId",
                Description = "Test description with edits",
                Url = "https://st2.depositphotos.com/1105977/5461/i/380/depositphotos_54615585-stock-photo-old-books-on-wooden-table.jpg"
            };

            var request = new RestRequest($"/api/Story/Edit/34re56tr");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Put);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(responseData.Msg, Is.EqualTo("No spoilers..."));
        }

        [Test, Order(6)]
        public void DeleteStory_WithIncorrectId_ShouldFaild()
        {
            var request = new RestRequest($"/api/Story/Delete/345re65");

            var response = client.Execute(request, Method.Delete);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Does.Contain("Unable to delete this story spoiler!"));
        }
    }
}