using APP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APP.Data
{
    public class RestService: IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
        public List<UsuarioItem> Items { get; private set; }
        public RestService()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            client = new HttpClient(insecureHandler);
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<UsuarioItem>> GetUsuariosAsync()
        {
            Items = new List<UsuarioItem>();

            Uri uri = new Uri(string.Format(Constants.UsuariosURL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<UsuarioItem>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<int> InsertUsuarioAsync(UsuarioItem item)
        {
            Uri uri = new Uri(string.Format(Constants.UsuariosURL, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<UsuarioItem>(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return 0;
            }
        }

        public async Task<int> UpdateUsuarioAsync(UsuarioItem item)
        {
            Uri uri = new Uri(string.Format(Constants.UsuariosURL, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<UsuarioItem>(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully Updated.");
                }
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return 0;
            }
        }

        public async Task<int> DeleteUsuarioAsync(UsuarioItem item)
        {
            Uri uri = new Uri(string.Format(Constants.UsuariosURL, item.Id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri + $"?id={item.Id}");
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }
                return 1;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return 0;
            }
        }

    }
}
