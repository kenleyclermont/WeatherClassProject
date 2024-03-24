/*
 * Auteur: Kenley Clermont
 * Date: 24/03/2024
 * Objectif: Ecrire une application mobile Maui à un seul écran pour afficher les informations
 * sur le temps et la température à Port-au-Prince en utilisant le modèle donné en classe. 
*/
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Maui.Models;

namespace Weather.Maui
{
    public partial class MainPage : ContentPage
    {
        private const string CURRENT_WEATHER_URL = "http://api.weatherapi.com/v1/current.json?key=c587c286165f410c9cd195332242403&q=Port-au-Prince&aqi=no";

        public MainPage()
        {
            InitializeComponent();
            LoadWeatherInfo();
        }
        public async void LoadWeatherInfo() 
        { 
            await LoadWeatherDataAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadWeatherDataAsync();
        }

        public async Task LoadWeatherDataAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage jsonResponse = await client.GetAsync(CURRENT_WEATHER_URL);

                if (jsonResponse.IsSuccessStatusCode)
                {
                    string stringResponse = await jsonResponse.Content.ReadAsStringAsync();
                    WeatherData? currentWeatherData = JsonConvert.DeserializeObject<WeatherData>(stringResponse);

                    if (currentWeatherData != null)
                    {
                        // Get Weather Information
                        // Get Location Name and Date
                        string location = currentWeatherData.Location.Name;
                        DateTime currentTime = DateTime.UtcNow;

                        // Get Condition Icon, Temperature and Condition
                        string conditionIconUrl = currentWeatherData.Current.Condition.Icon;
                        double temperature = currentWeatherData.Current.Temp_f;
                        string conditionText = currentWeatherData.Current.Condition.Text;

                        // Get Feelslike, Wind and Humidity
                        double feelsLike = currentWeatherData.Current.Feelslike_f;
                        double wind = currentWeatherData.Current.Wind_kph;
                        int humidity = currentWeatherData.Current.Humidity;
                        
                        // Update UI
                        // Update UI with Location Name and Date
                        LocationLabel.Text = location;
                        DateLabel.Text = currentTime.ToString("dddd, MMMM dd yyyy");

                        // Update UI with Condition Icon, Temperature and Condition
                        ConditionIcon.Source = conditionIconUrl; 
                        ConditionLabel.Text = conditionText;
                        TemperatureLabel.Text = $"{temperature}°F {conditionText}";
                        
                        // Update UI with Feelslike, Wind and Humidity
                        FeelsLikeLabel.Text = $"Feels like: {feelsLike}°F";
                        WindLabel.Text = $"Wind: {wind} kph";
                        HumidityLabel.Text = $"Humidity: {humidity}%";
                    }
                }
                else
                {
                    ErrorMessageLabel.Text = "Failed to fetch weather data";
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = $"Error: {ex.Message}";
            }
        }
    }
}