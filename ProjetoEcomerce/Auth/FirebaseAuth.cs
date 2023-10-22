using Newtonsoft.Json;
using ProjetoEcomerce.Models;
using System.Text;

namespace ProjetoEcomerce.Auth
{
    public class FirebaseAuth
    {

        private string apiKey;

        public FirebaseAuth(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<UsuarioRoot> SignInWithEmailAndPassword(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = $"https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key={apiKey}";

                var requestData = new
                {
                    email = email,
                    password = password,
                    returnSecureToken = true
                };

                string requestDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                var content = new StringContent(requestDataJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to sign in. Status code: {response.StatusCode}");
                }

                string responseContent = await response.Content.ReadAsStringAsync();
                UsuarioRoot responseData = JsonConvert.DeserializeObject<UsuarioRoot>(responseContent);



                return responseData;
            }
        }
    }
}

