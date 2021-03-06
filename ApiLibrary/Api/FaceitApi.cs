﻿using ApiLibrary.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiLibrary.Api
{
    public class FaceitApi  : IFaceitApi
    {

  
        HttpClient _httpClient;

        public FaceitApi( )

        {
            Initialize();
        }

        private void Initialize()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.BaseAddress = new Uri(GetFromConfig("BaseAddress"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {GetFromConfig("ApiKey")}");
        }

        private string GetFromConfig(string key)
        {
            var output = ConfigurationManager.AppSettings[key];

            return output;
        }

        public   async Task<FaceitPlayerModel> GetPlayerInformationsByName(string username)
        {

            using (HttpResponseMessage response = await _httpClient.GetAsync($"players?nickname={username}"))
            {
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    var output = JsonConvert.DeserializeObject<FaceitPlayerModel>(content);
                    return output;

                }

                else throw new Exception(response.ReasonPhrase);
            }
          

        }
        public async Task<FaceitCsgoModel> GetStatsByPlayerId(string id)
        {

            using (HttpResponseMessage response = await _httpClient.GetAsync($"players/{id}/stats/csgo"))
            {
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    var output = JsonConvert.DeserializeObject<FaceitCsgoModel>(content);
                    return output;

                }

                else throw new Exception(response.ReasonPhrase);
            }


        }

    }
}
