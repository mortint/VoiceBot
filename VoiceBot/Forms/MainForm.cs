using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace VoiceBot
{
    internal partial class MainForm : MaterialForm
    {
        /// <summary>
        /// Класс для работы с логом (открытия формы)
        /// </summary>
        private LogForm _formLog;
        /// <summary>
        /// Массив для хранения директорий с аудио
        /// </summary>
        private static string[] AudioFolders;
        /// <summary>
        /// Массив для хранения аудиофайлов
        /// </summary>
        private static string[] AudioFiles;
        /// <summary>
        /// Коллекция для хранения загруженных аккаунтов
        /// </summary>
        private static List<string> AccountsList;
        public MainForm()
        {
            InitializeComponent();

            AccountsList = new List<string>();
            Text += Application.ProductVersion;

            // Установка темы формы
            var instance = MaterialSkinManager.Instance;
            instance.AddFormToManage(this);
            instance.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue900, Primary.Red300, Accent.Red400, TextShade.WHITE);
            instance.Theme = MaterialSkinManager.Themes.DARK;
        }


        private void MessageSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MessageVoice.Text) || string.IsNullOrEmpty(FilesVoice.Text))
                LogForm.PushToLog("Отправка невозможна. Указаны не все данные.");
            else
            {
                var targets = target.Text;
                var filename = checkBox_selecFilePC.Checked ? MessageVoice.Text : $"Audio\\{FilesVoice.Text}\\{MessageVoice.Text}";

                new Task(() =>
                {
                    Invoke(new Action(() =>
                    {
                        // Вызов метода для отправки голосового сообщения
                        var token = AccountsList[curAcc.SelectedIndex];
                        Features.SendVoice(targets, filename, token);
                    }));
                }).Start();
            }
        }

        private void LoggingMenuItem_Click(object sender, EventArgs e)
        {
            _formLog?.Close();
            _formLog = new LogForm();
            _formLog.Show(this);
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            var materialSkinDll = "MaterialSkin.dll";
            var newtonsoftJsonDll = "Newtonsoft.Json.dll";
            var audioFolder = "Audio";
            var accountsFile = "accounts.txt";

            if (!File.Exists(materialSkinDll) || !File.Exists(newtonsoftJsonDll))
            {
                MessageBox.Show("Отсутствуют .dll для работы приложения", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            Directory.CreateDirectory(audioFolder);
            if (!File.Exists(accountsFile))
                File.Create(accountsFile).Close();

            var audioFolders = Directory.GetDirectories(audioFolder);

            foreach (var folder in audioFolders)
                FilesVoice.Items.Add(folder.Replace($"{audioFolder}\\", ""));

            // Авторизация загруженного аккаунта
            if (File.ReadAllLines(accountsFile).ToList().Count > 0)
            {
                try
                {
                    new Task(() =>
                    {
                        var accounts = File.ReadAllLines(accountsFile);

                        for (int i = 0; i < accounts.Length; i++)
                        {
                            var loginAndPassword = accounts[i].Split(':');

                            var vkServer = new VkServer
                            {
                                UserName = loginAndPassword[0],
                                Password = loginAndPassword[1]
                            };

                            AccountsList.Add(vkServer.GetToken());

                            Invoke(new Action(() =>
                            {
                                curAcc.Items.Add(accounts[i].Split(':')[0] + $" ({vkServer.UserInfo.Item1} {vkServer.UserInfo.Item2})");
                                curAcc.SelectedIndex = 0;
                            }));
                            LogForm.PushToLog("Авторизация аккаунтов завершена.");
                        }
                    }).Start();

                }
                catch
                {
                    LogForm.PushToLog("Не удалось авторизоваться.");
                    curAcc.Text = "Ошибка авторизации...";
                }
            }
        }

        /// <summary>
        /// Выбор директории с аудиофайлами
        /// </summary>
        private void FilesVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageVoice.Items.Clear();
            var selectedFolder = $"Audio\\{FilesVoice.Text}";

            if (Directory.Exists(selectedFolder))
            {
                var audioFiles = Directory.GetFiles(selectedFolder);

                foreach (var audio in audioFiles)
                    MessageVoice.Items.Add(Path.GetFileName(audio));
            }
            else
            {
                MessageBox.Show("Выбранная директория не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void helpMenuItem_Click(object sender, EventArgs e) => new HelpForm().Show();

        /// <summary>
        /// Загрузка аудиофайла
        /// </summary>
        private void button_selectFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_selecFilePC.Checked)
                {
                    var open = new OpenFileDialog
                    {
                        Filter = "MP3 (*.mp3)|*.mp3",
                        Title = "Добавить голосовое сообщение"
                    };

                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        MessageVoice.Items.Add(open.FileName);
                        MessageVoice.SelectedIndex = 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Выбор источника файлов
        /// </summary>
        private void checkBox_selecFilePC_CheckedChanged(object sender, EventArgs e)
        {
            FilesVoice.Enabled = checkBox_selecFilePC.Checked ? false : true;

            MessageVoice.Items.Clear();
            MessageVoice.Text = "";
        }
    }
}
