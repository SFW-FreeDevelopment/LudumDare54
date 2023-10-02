using System;
using System.Collections.Generic;
using LD54.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Proyecto26;
using UnityEngine;

namespace LD54.Clients
{
    public class ApiClient
    {
        private const string BaseURL = "https://ludumdare54api.azurewebsites.net";
        
        public static void SubmitHighscore(HighscoreDTO gameResults, Action<HighscoreDTO> successCallback)
        {
            const string url = BaseURL + "/scores";
            Debug.Log(url);
            var json = JsonConvert.SerializeObject(gameResults, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            Debug.Log(json);
            RestClient.Post(url, json)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                    var deserializedHighscore = JsonConvert.DeserializeObject<HighscoreDTO>(response.Text);
                    successCallback(deserializedHighscore);
                    Debug.Log(JsonConvert.SerializeObject(deserializedHighscore, Formatting.Indented));
                })
                .Catch(error =>
                {
                    Debug.Log($"Request failed: {json}");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not fetch the Highscore.{Environment.NewLine}{error?.Message}");
                });
        }
        
        public static void FetchTop10(Action<List<HighscoreDTO>> successCallback)
        {
            const string url = BaseURL + "/scores";
            Debug.Log(url);
        
            RestClient.Get(url)
                .Then(response =>
                {
                    Debug.Log("Request successful");
                    var deserializedHighscores = JsonConvert.DeserializeObject<List<HighscoreDTO>>(response.Text);
                    successCallback(deserializedHighscores);
                    Debug.Log(JsonConvert.SerializeObject(deserializedHighscores, Formatting.Indented));
                })
                .Catch(error =>
                {
                    Debug.Log("Request failed");
                    Debug.Log(error?.InnerException?.Message ?? "");
                    Debug.Log($"Could not fetch the Highscores.{Environment.NewLine}{error?.Message}");
                });
        }
    }
}