using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace VoiceBot
{
    public class Features
    {
        /// <summary>
        /// Отправка голосового сообщения 
        /// </summary>
        public static void SendVoice(string target, string filename, string token)
        {
            try
            {
                var uploadUrlResponse = JObject.Parse(VkServer.API("docs.getUploadServer", "type=audio_message", token));
                var uploadUrl = Convert.ToString(uploadUrlResponse["response"]["upload_url"]);

                var fileResponse = JObject.Parse(Helper.HttpUploadFile(uploadUrl, filename, "file", "audio/MP3"));
                var fileId = Convert.ToString(fileResponse["file"]);

                var saveDocsResponse = JObject.Parse(VkServer.API("docs.save", $"file={fileId}", token));
                var messageId = Convert.ToString(saveDocsResponse["response"]["audio_message"]["id"]);
                var ownerId = Convert.ToString(saveDocsResponse["response"]["audio_message"]["owner_id"]);

                var regexUser = new Regex("im\\?sel=([0-9]+)").Match(target);
                var regexChat = new Regex("im\\?sel=c([0-9]+)").Match(target);

                if (regexUser.Success)
                {
                    VkServer.API("messages.send", $"user_id={regexUser.Groups[1].Value}&attachment=doc{ownerId}_{messageId}&random_id", token);
                    LogForm.PushToLog($"Голосовое сообщение успешно отправлено в: {regexUser.Groups[1].Value}");
                }

                if (regexChat.Success)
                {
                    VkServer.API("messages.send", $"chat_id={regexChat.Groups[1].Value}&attachment=doc{ownerId}_{messageId}&random_id", token);
                    LogForm.PushToLog($"Голосовое сообщение успешно отправлено в: {regexChat.Groups[1].Value}");
                }
            }
            catch (Exception ex)
            {
                LogForm.PushToLog($"[API]: {ex.Message}");
            }
        }
    }
}


