namespace VoiceBot
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FilesVoice = new System.Windows.Forms.ComboBox();
            this.MessageVoice = new System.Windows.Forms.ComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.target = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.curAcc = new System.Windows.Forms.ComboBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.MessageSend = new MaterialSkin.Controls.MaterialRaisedButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loggingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_selecFilePC = new MaterialSkin.Controls.MaterialCheckBox();
            this.button_selectFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilesVoice
            // 
            this.FilesVoice.FormattingEnabled = true;
            this.FilesVoice.Location = new System.Drawing.Point(12, 88);
            this.FilesVoice.Name = "FilesVoice";
            this.FilesVoice.Size = new System.Drawing.Size(246, 21);
            this.FilesVoice.TabIndex = 0;
            this.FilesVoice.SelectedIndexChanged += new System.EventHandler(this.FilesVoice_SelectedIndexChanged);
            // 
            // MessageVoice
            // 
            this.MessageVoice.FormattingEnabled = true;
            this.MessageVoice.Location = new System.Drawing.Point(264, 88);
            this.MessageVoice.Name = "MessageVoice";
            this.MessageVoice.Size = new System.Drawing.Size(214, 21);
            this.MessageVoice.TabIndex = 1;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 66);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(246, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Папка с голосовым сообщением";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(260, 66);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(218, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Голосовое сообщение (.mp3)";
            // 
            // target
            // 
            this.target.Depth = 0;
            this.target.Hint = "Ссылка на цель";
            this.target.Location = new System.Drawing.Point(12, 143);
            this.target.MouseState = MaterialSkin.MouseState.HOVER;
            this.target.Name = "target";
            this.target.PasswordChar = '\0';
            this.target.SelectedText = "";
            this.target.SelectionLength = 0;
            this.target.SelectionStart = 0;
            this.target.Size = new System.Drawing.Size(466, 23);
            this.target.TabIndex = 4;
            this.target.UseSystemPasswordChar = false;
            // 
            // curAcc
            // 
            this.curAcc.FormattingEnabled = true;
            this.curAcc.Location = new System.Drawing.Point(174, 209);
            this.curAcc.Name = "curAcc";
            this.curAcc.Size = new System.Drawing.Size(304, 21);
            this.curAcc.TabIndex = 5;
            this.curAcc.Text = "Загрузка...";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 209);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(156, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Выбранный аккаунт:";
            // 
            // MessageSend
            // 
            this.MessageSend.Depth = 0;
            this.MessageSend.Location = new System.Drawing.Point(12, 170);
            this.MessageSend.MouseState = MaterialSkin.MouseState.HOVER;
            this.MessageSend.Name = "MessageSend";
            this.MessageSend.Primary = true;
            this.MessageSend.Size = new System.Drawing.Size(466, 33);
            this.MessageSend.TabIndex = 7;
            this.MessageSend.Text = "Отправить сообщение";
            this.MessageSend.UseVisualStyleBackColor = true;
            this.MessageSend.Click += new System.EventHandler(this.MessageSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggingMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(165, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loggingMenuItem
            // 
            this.loggingMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loggingMenuItem.Name = "loggingMenuItem";
            this.loggingMenuItem.Size = new System.Drawing.Size(92, 20);
            this.loggingMenuItem.Text = "Логирование";
            this.loggingMenuItem.Click += new System.EventHandler(this.LoggingMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpMenuItem.Text = "Справка";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // checkBox_selecFilePC
            // 
            this.checkBox_selecFilePC.AutoSize = true;
            this.checkBox_selecFilePC.Depth = 0;
            this.checkBox_selecFilePC.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBox_selecFilePC.Location = new System.Drawing.Point(7, 112);
            this.checkBox_selecFilePC.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox_selecFilePC.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBox_selecFilePC.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBox_selecFilePC.Name = "checkBox_selecFilePC";
            this.checkBox_selecFilePC.Ripple = true;
            this.checkBox_selecFilePC.Size = new System.Drawing.Size(292, 30);
            this.checkBox_selecFilePC.TabIndex = 9;
            this.checkBox_selecFilePC.Text = "Выбирать файл локально с компьютера";
            this.checkBox_selecFilePC.UseVisualStyleBackColor = true;
            this.checkBox_selecFilePC.CheckedChanged += new System.EventHandler(this.checkBox_selecFilePC_CheckedChanged);
            // 
            // button_selectFile
            // 
            this.button_selectFile.AutoSize = true;
            this.button_selectFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_selectFile.Depth = 0;
            this.button_selectFile.Location = new System.Drawing.Point(341, 112);
            this.button_selectFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button_selectFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_selectFile.Name = "button_selectFile";
            this.button_selectFile.Primary = false;
            this.button_selectFile.Size = new System.Drawing.Size(136, 36);
            this.button_selectFile.TabIndex = 10;
            this.button_selectFile.Text = "Добавить аудио";
            this.button_selectFile.UseVisualStyleBackColor = true;
            this.button_selectFile.Click += new System.EventHandler(this.button_selectFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 240);
            this.Controls.Add(this.button_selectFile);
            this.Controls.Add(this.checkBox_selecFilePC);
            this.Controls.Add(this.MessageSend);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.curAcc);
            this.Controls.Add(this.target);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.MessageVoice);
            this.Controls.Add(this.FilesVoice);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoiceBot v";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FilesVoice;
        private System.Windows.Forms.ComboBox MessageVoice;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField target;
        private System.Windows.Forms.ComboBox curAcc;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialRaisedButton MessageSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loggingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private MaterialSkin.Controls.MaterialCheckBox checkBox_selecFilePC;
        private MaterialSkin.Controls.MaterialFlatButton button_selectFile;
    }
}

