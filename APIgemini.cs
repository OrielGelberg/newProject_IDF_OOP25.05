using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
//using DotNetEnv;

namespace new25._05
{ 
internal class APIgemini
    {
        /// <summary>
        /// Calls the Gemini API and prints the response.
        /// </summary>
        public async Task CallGeminiApiAsync()
        {
            // TODO: Store your API key securely (e.g., in environment variables or a configuration file)

            // Construct the API request URL
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";
            HttpClient httpClient1 = new HttpClient();
            // Define the JSON request payload
            string json = @"{
            ""contents"": [
                {
                    ""parts"": [
                        {
                            ""text"": ""what is the best way to be normal?""
                        }
                    ]
                }
            ]
        }";

        //    string jsonBody = @"
        //        {
        //          ""contents"": [{
        //            ""parts"": [
        //              { ""text"": ""List a few popular cookie recipes, and include the amounts of ingredients."" }
        //            ]
        //          }],
        //          ""generationConfig"": {
        //            ""responseMimeType"": ""application/json"",
        //            ""responseSchema"": {
        //              ""type"": ""ARRAY"",
        //              ""items"": {
        //                ""type"": ""OBJECT"",
        //                ""properties"": {
        //                  ""recipeName"": {
        //                    ""type"": ""STRING"",
        //                    ""enum"": [""Percussion"", ""String"", ""Woodwind"", ""Brass"", ""Keyboard""],
        //                    },
        //                  ""ingredients"": {
        //                    ""type"": ""ARRAY"",
        //                    ""items"": { ""type"": ""STRING"" }
        //                  }
        //                },
        //                ""propertyOrdering"": [""recipeName"", ""ingredients""]
        //              }
        //            }
        //          }
        //        }";


        //    Console.WriteLine("Raw Text:\n" + resultText);

        //    var recipes = ParseRecipes(resultText);

        //    Console.WriteLine("\nParsed Recipes:");
        //    if (recipes != null)
        //    {
        //        foreach (var recipe in recipes)
        //        {
        //            Console.WriteLine($"🍪 {recipe.recipeName}");
        //            if (recipe.ingredients != null)
        //            {
        //                foreach (var ingredient in recipe.ingredients)
        //                {
        //                    Console.WriteLine($"  - {ingredient}");
        //                }
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        //public static List<Recipe>? ParseRecipes(string? json)
        //{
        //    if (string.IsNullOrWhiteSpace(json)) return null;
        //    return JsonSerializer.Deserialize<List<Recipe>>(json);
        //}

        //public class Recipe
        //{
        //    public string? recipeName { get; set; }
        //    public List<string>? ingredients { get; set; }
        //}


















































        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            // Set the request content type to application/json
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            // Add the API key to the request headers

            HttpResponseMessage response = await httpClient1.SendAsync(request); // Fixed type to HttpResponseMessage
            // Ensure the response is successful
            string responseContent = await response.Content.ReadAsStringAsync();

            JsonDocument jsonResponse = JsonDocument.Parse(responseContent);
            //string generatedText = doc.RootElement
            //    .GetProperty("candidates")[0]
            //    .GetProperty("content")
            //    .GetProperty("parts")[0]
            //    .GetProperty("text")
            //    .GetString();




            // Use HttpClient to send the request
            using (var httpClient = new HttpClient())
            {
                // Create HttpContent with correct encoding and content type
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Send the HTTP POST request asynchronously
                    var response2 = await httpClient.PostAsync(url, content);

                    // Ensure a successful response
                    response2.EnsureSuccessStatusCode();

                    // Read the response content as a string
                    string responseString = await response2.Content.ReadAsStringAsync();

                    // Print the response to the console
                    Console.WriteLine("Response:");
                    Console.WriteLine(responseString);
                }
                catch (HttpRequestException httpEx)
                {
                    // Handle HTTP request errors
                    Console.WriteLine("HTTP Request Error:");
                    Console.WriteLine(httpEx.Message);
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    Console.WriteLine("Unexpected Error:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}





