namespace SQLTrace.Controls
{
    partial class GeneralTracePropertiesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.authenticationLabel = new System.Windows.Forms.Label();
            this.authenticationComboBox = new System.Windows.Forms.ComboBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.traceNameLabel = new System.Windows.Forms.Label();
            this.traceNameTextBox = new System.Windows.Forms.TextBox();
            this.saveToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.setMaximumSizeLabel = new System.Windows.Forms.Label();
            this.setMaximumSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.enableFileRolloverCheckBox = new System.Windows.Forms.CheckBox();
            this.saveToTableCheckBox = new System.Windows.Forms.CheckBox();
            this.saveToTableTextBox = new System.Windows.Forms.TextBox();
            this.setMaximimRowsCheckBox = new System.Windows.Forms.CheckBox();
            this.maximumRowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveToTableButton = new System.Windows.Forms.Button();
            this.RawConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.rawConnectionStringCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveToFileFileSelectorControl = new Attech.FlightMonitor.UI.Controls.FileSelectorControl();
            this.horizontalRule1 = new Attech.FlightMonitor.UI.Controls.HorizontalRule();
            this.traceOptionsHorizontalRule = new Attech.FlightMonitor.UI.Controls.HorizontalRule();
            this.serverConnectionHorizontalRule = new Attech.FlightMonitor.UI.Controls.HorizontalRule();
            this.savePasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userNameComboBox = new System.Windows.Forms.ComboBox();
            this.serverNameComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.setMaximumSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRowsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(71, 28);
            this.serverNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(75, 15);
            this.serverNameLabel.TabIndex = 13;
            this.serverNameLabel.Text = "服务器名:";
            // 
            // authenticationLabel
            // 
            this.authenticationLabel.AutoSize = true;
            this.authenticationLabel.Location = new System.Drawing.Point(71, 59);
            this.authenticationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.authenticationLabel.Name = "authenticationLabel";
            this.authenticationLabel.Size = new System.Drawing.Size(75, 15);
            this.authenticationLabel.TabIndex = 14;
            this.authenticationLabel.Text = "验证方式:";
            // 
            // authenticationComboBox
            // 
            this.authenticationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authenticationComboBox.FormattingEnabled = true;
            this.authenticationComboBox.Location = new System.Drawing.Point(157, 55);
            this.authenticationComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.authenticationComboBox.Name = "authenticationComboBox";
            this.authenticationComboBox.Size = new System.Drawing.Size(368, 23);
            this.authenticationComboBox.TabIndex = 1;
            this.authenticationComboBox.SelectedIndexChanged += new System.EventHandler(this.authenticationComboBox_SelectedIndexChanged);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(86, 90);
            this.userNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(60, 15);
            this.userNameLabel.TabIndex = 15;
            this.userNameLabel.Text = "用户名:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(101, 121);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(45, 15);
            this.passwordLabel.TabIndex = 16;
            this.passwordLabel.Text = "密码:";
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testConnectionButton.Location = new System.Drawing.Point(624, 181);
            this.testConnectionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(124, 27);
            this.testConnectionButton.TabIndex = 4;
            this.testConnectionButton.Text = "测试连接";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // traceNameLabel
            // 
            this.traceNameLabel.AutoSize = true;
            this.traceNameLabel.Location = new System.Drawing.Point(71, 241);
            this.traceNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.traceNameLabel.Name = "traceNameLabel";
            this.traceNameLabel.Size = new System.Drawing.Size(75, 15);
            this.traceNameLabel.TabIndex = 18;
            this.traceNameLabel.Text = "跟踪名称:";
            // 
            // traceNameTextBox
            // 
            this.traceNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.traceNameTextBox.Location = new System.Drawing.Point(157, 238);
            this.traceNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.traceNameTextBox.Name = "traceNameTextBox";
            this.traceNameTextBox.Size = new System.Drawing.Size(591, 25);
            this.traceNameTextBox.TabIndex = 5;
            this.traceNameTextBox.Text = "新建跟踪";
            // 
            // saveToFileCheckBox
            // 
            this.saveToFileCheckBox.AutoSize = true;
            this.saveToFileCheckBox.Enabled = false;
            this.saveToFileCheckBox.Location = new System.Drawing.Point(32, 291);
            this.saveToFileCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveToFileCheckBox.Name = "saveToFileCheckBox";
            this.saveToFileCheckBox.Size = new System.Drawing.Size(112, 19);
            this.saveToFileCheckBox.TabIndex = 20;
            this.saveToFileCheckBox.Text = "保存到文件:";
            this.saveToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // setMaximumSizeLabel
            // 
            this.setMaximumSizeLabel.AutoSize = true;
            this.setMaximumSizeLabel.Enabled = false;
            this.setMaximumSizeLabel.Location = new System.Drawing.Point(156, 323);
            this.setMaximumSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.setMaximumSizeLabel.Name = "setMaximumSizeLabel";
            this.setMaximumSizeLabel.Size = new System.Drawing.Size(129, 15);
            this.setMaximumSizeLabel.TabIndex = 22;
            this.setMaximumSizeLabel.Text = "设置最大空间(MB)";
            // 
            // setMaximumSizeNumericUpDown
            // 
            this.setMaximumSizeNumericUpDown.Enabled = false;
            this.setMaximumSizeNumericUpDown.Location = new System.Drawing.Point(296, 320);
            this.setMaximumSizeNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setMaximumSizeNumericUpDown.Name = "setMaximumSizeNumericUpDown";
            this.setMaximumSizeNumericUpDown.Size = new System.Drawing.Size(77, 25);
            this.setMaximumSizeNumericUpDown.TabIndex = 8;
            this.setMaximumSizeNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.setMaximumSizeNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // enableFileRolloverCheckBox
            // 
            this.enableFileRolloverCheckBox.AutoSize = true;
            this.enableFileRolloverCheckBox.Enabled = false;
            this.enableFileRolloverCheckBox.Location = new System.Drawing.Point(157, 350);
            this.enableFileRolloverCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.enableFileRolloverCheckBox.Name = "enableFileRolloverCheckBox";
            this.enableFileRolloverCheckBox.Size = new System.Drawing.Size(189, 19);
            this.enableFileRolloverCheckBox.TabIndex = 23;
            this.enableFileRolloverCheckBox.Text = "Enable file rollover";
            this.enableFileRolloverCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveToTableCheckBox
            // 
            this.saveToTableCheckBox.AutoSize = true;
            this.saveToTableCheckBox.Enabled = false;
            this.saveToTableCheckBox.Location = new System.Drawing.Point(43, 388);
            this.saveToTableCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveToTableCheckBox.Name = "saveToTableCheckBox";
            this.saveToTableCheckBox.Size = new System.Drawing.Size(97, 19);
            this.saveToTableCheckBox.TabIndex = 21;
            this.saveToTableCheckBox.Text = "保存到表:";
            this.saveToTableCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveToTableTextBox
            // 
            this.saveToTableTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToTableTextBox.Enabled = false;
            this.saveToTableTextBox.Location = new System.Drawing.Point(157, 385);
            this.saveToTableTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveToTableTextBox.Name = "saveToTableTextBox";
            this.saveToTableTextBox.Size = new System.Drawing.Size(557, 25);
            this.saveToTableTextBox.TabIndex = 9;
            // 
            // setMaximimRowsCheckBox
            // 
            this.setMaximimRowsCheckBox.AutoSize = true;
            this.setMaximimRowsCheckBox.Enabled = false;
            this.setMaximimRowsCheckBox.Location = new System.Drawing.Point(157, 419);
            this.setMaximimRowsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setMaximimRowsCheckBox.Name = "setMaximimRowsCheckBox";
            this.setMaximimRowsCheckBox.Size = new System.Drawing.Size(180, 19);
            this.setMaximimRowsCheckBox.TabIndex = 0;
            this.setMaximimRowsCheckBox.Text = "设置最大行(单位为千)";
            this.setMaximimRowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // maximumRowsNumericUpDown
            // 
            this.maximumRowsNumericUpDown.Enabled = false;
            this.maximumRowsNumericUpDown.Location = new System.Drawing.Point(435, 416);
            this.maximumRowsNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.maximumRowsNumericUpDown.Name = "maximumRowsNumericUpDown";
            this.maximumRowsNumericUpDown.Size = new System.Drawing.Size(77, 25);
            this.maximumRowsNumericUpDown.TabIndex = 11;
            this.maximumRowsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveToTableButton
            // 
            this.saveToTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToTableButton.Enabled = false;
            this.saveToTableButton.Image = global::SQLTrace.Properties.Resources.s_h_cuelist;
            this.saveToTableButton.Location = new System.Drawing.Point(719, 384);
            this.saveToTableButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveToTableButton.Name = "saveToTableButton";
            this.saveToTableButton.Size = new System.Drawing.Size(32, 25);
            this.saveToTableButton.TabIndex = 10;
            this.saveToTableButton.Text = "button1";
            this.saveToTableButton.UseVisualStyleBackColor = true;
            // 
            // RawConnectionStringTextBox
            // 
            this.RawConnectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RawConnectionStringTextBox.Enabled = false;
            this.RawConnectionStringTextBox.Location = new System.Drawing.Point(157, 151);
            this.RawConnectionStringTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RawConnectionStringTextBox.Name = "RawConnectionStringTextBox";
            this.RawConnectionStringTextBox.Size = new System.Drawing.Size(592, 25);
            this.RawConnectionStringTextBox.TabIndex = 24;
            // 
            // rawConnectionStringCheckBox
            // 
            this.rawConnectionStringCheckBox.AutoSize = true;
            this.rawConnectionStringCheckBox.Location = new System.Drawing.Point(11, 153);
            this.rawConnectionStringCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rawConnectionStringCheckBox.Name = "rawConnectionStringCheckBox";
            this.rawConnectionStringCheckBox.Size = new System.Drawing.Size(112, 19);
            this.rawConnectionStringCheckBox.TabIndex = 25;
            this.rawConnectionStringCheckBox.Text = "连接字符串:";
            this.rawConnectionStringCheckBox.UseVisualStyleBackColor = true;
            this.rawConnectionStringCheckBox.CheckedChanged += new System.EventHandler(this.rawConnectionStringCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(7, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(588, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "注意: 添加 \';Application Name=sqlprofilerapp\'到连接字符串可以过滤掉本程序的连查询语句";
            this.label1.Visible = false;
            // 
            // saveToFileFileSelectorControl
            // 
            this.saveToFileFileSelectorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToFileFileSelectorControl.Enabled = false;
            this.saveToFileFileSelectorControl.FileName = "";
            this.saveToFileFileSelectorControl.Filter = "";
            this.saveToFileFileSelectorControl.Location = new System.Drawing.Point(157, 288);
            this.saveToFileFileSelectorControl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.saveToFileFileSelectorControl.Name = "saveToFileFileSelectorControl";
            this.saveToFileFileSelectorControl.Size = new System.Drawing.Size(591, 24);
            this.saveToFileFileSelectorControl.TabIndex = 7;
            this.saveToFileFileSelectorControl.Load += new System.EventHandler(this.fileSelectorControl1_Load);
            // 
            // horizontalRule1
            // 
            this.horizontalRule1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalRule1.Location = new System.Drawing.Point(4, 267);
            this.horizontalRule1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.horizontalRule1.Name = "horizontalRule1";
            this.horizontalRule1.Size = new System.Drawing.Size(763, 16);
            this.horizontalRule1.TabIndex = 19;
            this.horizontalRule1.Text = "保存";
            // 
            // traceOptionsHorizontalRule
            // 
            this.traceOptionsHorizontalRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.traceOptionsHorizontalRule.Location = new System.Drawing.Point(4, 215);
            this.traceOptionsHorizontalRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.traceOptionsHorizontalRule.Name = "traceOptionsHorizontalRule";
            this.traceOptionsHorizontalRule.Size = new System.Drawing.Size(763, 16);
            this.traceOptionsHorizontalRule.TabIndex = 17;
            this.traceOptionsHorizontalRule.Text = "跟踪选项";
            // 
            // serverConnectionHorizontalRule
            // 
            this.serverConnectionHorizontalRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverConnectionHorizontalRule.Location = new System.Drawing.Point(4, 3);
            this.serverConnectionHorizontalRule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.serverConnectionHorizontalRule.Name = "serverConnectionHorizontalRule";
            this.serverConnectionHorizontalRule.Size = new System.Drawing.Size(763, 16);
            this.serverConnectionHorizontalRule.TabIndex = 12;
            this.serverConnectionHorizontalRule.Text = "服务器连接";
            // 
            // savePasswordCheckBox
            // 
            this.savePasswordCheckBox.AutoSize = true;
            this.savePasswordCheckBox.Checked = global::SQLTrace.Properties.Settings.Default.SavePassword;
            this.savePasswordCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::SQLTrace.Properties.Settings.Default, "SavePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.savePasswordCheckBox.Location = new System.Drawing.Point(536, 121);
            this.savePasswordCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.savePasswordCheckBox.Name = "savePasswordCheckBox";
            this.savePasswordCheckBox.Size = new System.Drawing.Size(89, 19);
            this.savePasswordCheckBox.TabIndex = 26;
            this.savePasswordCheckBox.Text = "保存密码";
            this.savePasswordCheckBox.UseVisualStyleBackColor = true;
            this.savePasswordCheckBox.CheckedChanged += new System.EventHandler(this.savePasswordCheckBox_CheckedChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(157, 118);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(368, 25);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = global::SQLTrace.Properties.Settings.Default.Password;
            // 
            // userNameComboBox
            // 
            this.userNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.userNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.userNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SQLTrace.Properties.Settings.Default, "LastUserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.userNameComboBox.FormattingEnabled = true;
            this.userNameComboBox.Location = new System.Drawing.Point(157, 87);
            this.userNameComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.userNameComboBox.Name = "userNameComboBox";
            this.userNameComboBox.Size = new System.Drawing.Size(368, 23);
            this.userNameComboBox.TabIndex = 2;
            this.userNameComboBox.Text = global::SQLTrace.Properties.Settings.Default.LastUserName;
            // 
            // serverNameComboBox
            // 
            this.serverNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serverNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.serverNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SQLTrace.Properties.Settings.Default, "LastServerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.serverNameComboBox.FormattingEnabled = true;
            this.serverNameComboBox.Location = new System.Drawing.Point(157, 24);
            this.serverNameComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.serverNameComboBox.Name = "serverNameComboBox";
            this.serverNameComboBox.Size = new System.Drawing.Size(368, 23);
            this.serverNameComboBox.TabIndex = 0;
            this.serverNameComboBox.Text = global::SQLTrace.Properties.Settings.Default.LastServerName;
            this.serverNameComboBox.DropDown += new System.EventHandler(this.serverNameComboBox_DropDown);
            // 
            // GeneralTracePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.savePasswordCheckBox);
            this.Controls.Add(this.rawConnectionStringCheckBox);
            this.Controls.Add(this.RawConnectionStringTextBox);
            this.Controls.Add(this.maximumRowsNumericUpDown);
            this.Controls.Add(this.setMaximimRowsCheckBox);
            this.Controls.Add(this.saveToTableButton);
            this.Controls.Add(this.saveToTableTextBox);
            this.Controls.Add(this.saveToTableCheckBox);
            this.Controls.Add(this.enableFileRolloverCheckBox);
            this.Controls.Add(this.setMaximumSizeNumericUpDown);
            this.Controls.Add(this.setMaximumSizeLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.saveToFileFileSelectorControl);
            this.Controls.Add(this.saveToFileCheckBox);
            this.Controls.Add(this.horizontalRule1);
            this.Controls.Add(this.traceNameTextBox);
            this.Controls.Add(this.traceNameLabel);
            this.Controls.Add(this.testConnectionButton);
            this.Controls.Add(this.traceOptionsHorizontalRule);
            this.Controls.Add(this.userNameComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.authenticationComboBox);
            this.Controls.Add(this.authenticationLabel);
            this.Controls.Add(this.serverNameComboBox);
            this.Controls.Add(this.serverNameLabel);
            this.Controls.Add(this.serverConnectionHorizontalRule);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GeneralTracePropertiesControl";
            this.Size = new System.Drawing.Size(771, 489);
            this.Load += new System.EventHandler(this.GeneralTracePropertiesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.setMaximumSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumRowsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Attech.FlightMonitor.UI.Controls.HorizontalRule serverConnectionHorizontalRule;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.ComboBox serverNameComboBox;
        private System.Windows.Forms.Label authenticationLabel;
        private System.Windows.Forms.ComboBox authenticationComboBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ComboBox userNameComboBox;
        private System.Windows.Forms.Button testConnectionButton;
        private Attech.FlightMonitor.UI.Controls.HorizontalRule traceOptionsHorizontalRule;
        private System.Windows.Forms.Label traceNameLabel;
        private System.Windows.Forms.TextBox traceNameTextBox;
        private Attech.FlightMonitor.UI.Controls.HorizontalRule horizontalRule1;
        private System.Windows.Forms.CheckBox saveToFileCheckBox;
        private Attech.FlightMonitor.UI.Controls.FileSelectorControl saveToFileFileSelectorControl;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label setMaximumSizeLabel;
        private System.Windows.Forms.NumericUpDown setMaximumSizeNumericUpDown;
        private System.Windows.Forms.CheckBox enableFileRolloverCheckBox;
        private System.Windows.Forms.CheckBox saveToTableCheckBox;
        private System.Windows.Forms.TextBox saveToTableTextBox;
        private System.Windows.Forms.Button saveToTableButton;
        private System.Windows.Forms.CheckBox setMaximimRowsCheckBox;
        private System.Windows.Forms.NumericUpDown maximumRowsNumericUpDown;
        private System.Windows.Forms.TextBox RawConnectionStringTextBox;
        private System.Windows.Forms.CheckBox rawConnectionStringCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox savePasswordCheckBox;
    }
}
