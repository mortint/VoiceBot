using System;
using System.IO;
using System.Net;
using System.Text;

namespace VoiceBot
{
    public static class Helper
    {
        /// <summary>
        /// GET запрос
        /// </summary>
        public static string Get(string url)
        {
            try
            {
                var http = (HttpWebRequest)WebRequest.Create(url);
                http.Method = "GET";

                using (var hwr = (HttpWebResponse)http.GetResponse())
                {
                    using (var stream = hwr.GetResponseStream())
                    {
                        using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Загрузка файла
        /// </summary>
        public static string HttpUploadFile(string url, string file, string paramName, string contentType)
        {
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            var boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            var hwr = (HttpWebRequest)WebRequest.Create(url);
            hwr.ContentType = "multipart/form-data; boundary=" + boundary;
            hwr.Method = "POST";
            hwr.KeepAlive = true;
            hwr.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.61 Safari/537.36";

            using (var rs = hwr.GetRequestStream())
            {
                rs.Write(boundaryBytes, 0, boundaryBytes.Length);

                var fileHeader = string.Format(
                    "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, file, contentType);
                var fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);
                rs.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[4096];
                    int bytesRead;

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                    }
                }

                byte[] closingBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(closingBytes, 0, closingBytes.Length);
            }

            string result = string.Empty;

            try
            {
                using (var webResponse = hwr.GetResponse())
                {
                    using (var streamReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return result;
        }
    }
}
