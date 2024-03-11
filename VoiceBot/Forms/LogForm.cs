using System;
using System.Collections.Generic;
using MaterialSkin.Controls;

namespace VoiceBot
{
    internal partial class LogForm : MaterialForm
    {
        private static readonly LinkedList<string> Logs = new LinkedList<string>();
        /// <summary>
        /// Вывод сообщения в лог
        /// </summary>
        /// <param name="info"></param>
        public static void PushToLog(string info)
        {
            Logs.AddFirst($"[{DateTime.Now.ToShortTimeString()}]: {info}");
        }
        public LogForm()
        {
            InitializeComponent();
            LogTimer_Tick(null, null);
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            lock (Logs)
            {
                TextLog.Clear();

                foreach (string entry in Logs)
                    TextLog.Text += entry + "\n";

                if (Logs.Count > 100)
                    Logs.RemoveLast();
            }
        }
    }
}
