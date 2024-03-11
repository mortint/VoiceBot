using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace VoiceBot
{
    class VkServer
    {
        /// <summary>
        /// Поле для хранение логина 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Поле для хранения пароля
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Поле для хранения информации о пользователе
        /// </summary>
        public (string, string) UserInfo;
        /// <summary>
        /// Получение токена ВК
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            var wc = new WebClient { Encoding = Encoding.UTF8 };

            var clientId = 0;
            var clientSecret = string.Empty;

            Applications applications = GetApplications();

            switch (applications)
            {
                case Applications.Android:
                    clientId = (int)Applications.Android;
                    clientSecret = "hHbZxrka2uZ6jB1inYsH";
                    break;
                case Applications.WindowsPhone:
                    clientId = (int)Applications.WindowsPhone;
                    clientSecret = "AlVXZFMUqyrnABp8ncuU";
                    break;
            }

            var json = JObject.Parse(wc.UploadString($"https://oauth.vk.com/token?grant_type=password&client_id={clientId}&client_secret={clientSecret}&username={UserName}&password={Password}&v=5.131&2fa_supported=1", "nothing"));

            var token = Convert.ToString(json["access_token"]);
            GetName(token);
            return token;
        }
        /// <summary>
        /// Запрос к API VK для выполнения методов
        /// </summary>
        public static string API(string method, string arguments, string token)
        {
            return Helper.Get($"https://api.vk.com/api.php?oauth=1&method={method}&{arguments}&v=5.131&access_token={token}");
        }
        /// <summary>
        /// Получение информации о текущем аккаунте
        /// </summary>
        private void GetName(string token)
        {
            var response = API("users.get", "", token);
            var json = JObject.Parse(response);
            UserInfo.Item1 = Convert.ToString(json["response"][0]["first_name"]);
            UserInfo.Item2 = Convert.ToString(json["response"][0]["last_name"]);
        }
        /// <summary>
        /// Получение случайного приложения для авторизации
        /// </summary>
        /// <returns></returns>
        private Applications GetApplications()
        {
            var random = new Random();

            Applications applications;

            switch (random.Next(1, 3))
            {
                case 1:
                    applications = Applications.Android;
                    break;
                case 2:
                    applications = Applications.WindowsPhone;
                    break;
                default:
                    applications = Applications.Android;
                    break;
            }

            return applications;
        }
        /// <summary>
        /// Перечисления ID приложений для авторизации
        /// </summary>
        private enum Applications
        {
            None = 0,
            Android = 2274003,
            WindowsPhone = 3697615
        }
    }

}
