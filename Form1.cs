using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using System.Net.Http.Headers;
using RapidAPISDK;
using Newtonsoft.Json;
using Microsoft.Data.Sqlite;
using WindowsFormsApp4.Models;
using WindowsFormsApp4.DAL;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CountryRepository countryRepository = new CountryRepository();
        //HashSet<Country> countries = new HashSet<Country>();
       

        private async void button1_Click(object sender, EventArgs e)
        {
            var code = textBox1.Text;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-19-data.p.rapidapi.com/country/code?code="+code),
                Headers =
    {
        { "x-rapidapi-host", "covid-19-data.p.rapidapi.com" },
        { "x-rapidapi-key", "ae026ee544msh8175b8e796b3910p1c9e67jsne8791b69f46e" },
    },
            };
            using (var response =  client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

             
                dynamic stuff = JsonConvert.DeserializeObject(body);
                var land = stuff[0].country;
                var confirmed = stuff[0].confirmed;
                Country.Text= land.ToString();
                Confirmed.Text = confirmed;
                //Country country = new Country { Code = code, Name = result};
              
            }
        }

      
    }
}
