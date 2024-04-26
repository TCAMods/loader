namespace ModLoader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Setup = new TabPage();
            label2 = new Label();
            label1 = new Label();
            selectFolderButton = new Button();
            tcaGameFolderTextBox = new TextBox();
            Loadouts = new TabPage();
            splitContainer1 = new SplitContainer();
            loadoutsTreeView = new TreeView();
            loadoutVersionNumber = new Label();
            loadoutAuthorLabel = new Label();
            loadoutInstallButton = new Button();
            loadoutDescription = new Label();
            loadoutTitle = new Label();
            tcaFolderBrowser = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            Setup.SuspendLayout();
            Loadouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Setup);
            tabControl1.Controls.Add(Loadouts);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            tabControl1.Selected += tabControl1_Selected;
            // 
            // Setup
            // 
            Setup.Controls.Add(label2);
            Setup.Controls.Add(label1);
            Setup.Controls.Add(selectFolderButton);
            Setup.Controls.Add(tcaGameFolderTextBox);
            Setup.Location = new Point(4, 24);
            Setup.Name = "Setup";
            Setup.Padding = new Padding(3);
            Setup.Size = new Size(792, 422);
            Setup.TabIndex = 0;
            Setup.Text = "Setup";
            Setup.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 97);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 3;
            label2.Text = "2. Done! Now go to other tab";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 40);
            label1.Name = "label1";
            label1.Size = new Size(168, 15);
            label1.TabIndex = 2;
            label1.Text = "1. Select your TCA game folder";
            // 
            // selectFolderButton
            // 
            selectFolderButton.Location = new Point(359, 58);
            selectFolderButton.Name = "selectFolderButton";
            selectFolderButton.Size = new Size(122, 23);
            selectFolderButton.TabIndex = 1;
            selectFolderButton.Text = "Select Folder";
            selectFolderButton.UseVisualStyleBackColor = true;
            selectFolderButton.Click += selectFolderButton_Click;
            // 
            // tcaGameFolderTextBox
            // 
            tcaGameFolderTextBox.Location = new Point(46, 58);
            tcaGameFolderTextBox.Name = "tcaGameFolderTextBox";
            tcaGameFolderTextBox.PlaceholderText = "Your TCA game folder here";
            tcaGameFolderTextBox.Size = new Size(307, 23);
            tcaGameFolderTextBox.TabIndex = 0;
            // 
            // Loadouts
            // 
            Loadouts.Controls.Add(splitContainer1);
            Loadouts.Location = new Point(4, 24);
            Loadouts.Name = "Loadouts";
            Loadouts.Padding = new Padding(3);
            Loadouts.Size = new Size(792, 422);
            Loadouts.TabIndex = 1;
            Loadouts.Text = "Loadouts";
            Loadouts.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(loadoutsTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(loadoutVersionNumber);
            splitContainer1.Panel2.Controls.Add(loadoutAuthorLabel);
            splitContainer1.Panel2.Controls.Add(loadoutInstallButton);
            splitContainer1.Panel2.Controls.Add(loadoutDescription);
            splitContainer1.Panel2.Controls.Add(loadoutTitle);
            splitContainer1.Size = new Size(786, 416);
            splitContainer1.SplitterDistance = 262;
            splitContainer1.TabIndex = 0;
            // 
            // loadoutsTreeView
            // 
            loadoutsTreeView.Dock = DockStyle.Fill;
            loadoutsTreeView.Location = new Point(0, 0);
            loadoutsTreeView.Name = "loadoutsTreeView";
            loadoutsTreeView.Size = new Size(262, 416);
            loadoutsTreeView.TabIndex = 0;
            loadoutsTreeView.AfterSelect += loadoutsTreeView_AfterSelect;
            // 
            // loadoutVersionNumber
            // 
            loadoutVersionNumber.AutoEllipsis = true;
            loadoutVersionNumber.ForeColor = SystemColors.ControlDark;
            loadoutVersionNumber.Location = new Point(183, 57);
            loadoutVersionNumber.Name = "loadoutVersionNumber";
            loadoutVersionNumber.Size = new Size(130, 17);
            loadoutVersionNumber.TabIndex = 3;
            loadoutVersionNumber.Text = "1.0.0";
            // 
            // loadoutAuthorLabel
            // 
            loadoutAuthorLabel.AutoEllipsis = true;
            loadoutAuthorLabel.ForeColor = SystemColors.ControlDark;
            loadoutAuthorLabel.Location = new Point(47, 57);
            loadoutAuthorLabel.Name = "loadoutAuthorLabel";
            loadoutAuthorLabel.Size = new Size(130, 17);
            loadoutAuthorLabel.TabIndex = 2;
            loadoutAuthorLabel.Text = "by Hanz";
            // 
            // loadoutInstallButton
            // 
            loadoutInstallButton.Location = new Point(397, 27);
            loadoutInstallButton.Name = "loadoutInstallButton";
            loadoutInstallButton.Size = new Size(93, 23);
            loadoutInstallButton.TabIndex = 1;
            loadoutInstallButton.Text = "Install";
            loadoutInstallButton.UseVisualStyleBackColor = true;
            loadoutInstallButton.Click += loadoutInstallButton_Click;
            loadoutInstallButton.MouseEnter += loadoutInstallButton_MouseEnter;
            loadoutInstallButton.MouseLeave += loadoutInstallButton_MouseLeave;
            // 
            // loadoutDescription
            // 
            loadoutDescription.AutoEllipsis = true;
            loadoutDescription.ForeColor = SystemColors.ControlDarkDark;
            loadoutDescription.Location = new Point(41, 100);
            loadoutDescription.Name = "loadoutDescription";
            loadoutDescription.Size = new Size(400, 200);
            loadoutDescription.TabIndex = 0;
            loadoutDescription.Text = "Expand the tree view and select your desired loadout for your aircraft";
            // 
            // loadoutTitle
            // 
            loadoutTitle.AutoEllipsis = true;
            loadoutTitle.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadoutTitle.Location = new Point(35, 22);
            loadoutTitle.Name = "loadoutTitle";
            loadoutTitle.Size = new Size(350, 30);
            loadoutTitle.TabIndex = 0;
            loadoutTitle.Text = "Custom Loadouts";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "ModLoader";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            Setup.ResumeLayout(false);
            Setup.PerformLayout();
            Loadouts.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Setup;
        private TabPage Loadouts;
        private Label label2;
        private Label label1;
        private Button selectFolderButton;
        private TextBox tcaGameFolderTextBox;
        private FolderBrowserDialog tcaFolderBrowser;
        private SplitContainer splitContainer1;
        private TreeView loadoutsTreeView;
        private Label loadoutDescription;
        private Label loadoutTitle;
        private Button loadoutInstallButton;
        private Label loadoutVersionNumber;
        private Label loadoutAuthorLabel;
    }
}
