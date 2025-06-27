namespace CyberSecurityAwarenessBot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.sendButton = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.userInput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showTasksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemindersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showActivityLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startQuizMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(800, 505);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(150, 30);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(42, 60);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(921, 420);
            this.chatBox.TabIndex = 1;
            this.chatBox.Text = "";
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(42, 510);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(720, 22);
            this.userInput.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTasksMenuItem,
            this.showRemindersMenuItem,
            this.showActivityLogMenuItem,
            this.startQuizMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showTasksMenuItem
            // 
            this.showTasksMenuItem.Name = "showTasksMenuItem";
            this.showTasksMenuItem.Size = new System.Drawing.Size(94, 24);
            this.showTasksMenuItem.Text = "Show Tasks";
            this.showTasksMenuItem.Click += new System.EventHandler(this.showTasksMenuItem_Click);
            // 
            // showRemindersMenuItem
            // 
            this.showRemindersMenuItem.Name = "showRemindersMenuItem";
            this.showRemindersMenuItem.Size = new System.Drawing.Size(130, 24);
            this.showRemindersMenuItem.Text = "Show Reminders";
            this.showRemindersMenuItem.Click += new System.EventHandler(this.showRemindersMenuItem_Click);
            // 
            // showActivityLogMenuItem
            // 
            this.showActivityLogMenuItem.Name = "showActivityLogMenuItem";
            this.showActivityLogMenuItem.Size = new System.Drawing.Size(130, 24);
            this.showActivityLogMenuItem.Text = "Show Activity Log";
            this.showActivityLogMenuItem.Click += new System.EventHandler(this.showActivityLogMenuItem_Click);
            // 
            // startQuizMenuItem
            // 
            this.startQuizMenuItem.Name = "startQuizMenuItem";
            this.startQuizMenuItem.Size = new System.Drawing.Size(84, 24);
            this.startQuizMenuItem.Text = "Start Quiz";
            this.startQuizMenuItem.Click += new System.EventHandler(this.startQuizMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(400, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "CYBER SECURITY AWARENESS BOT";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cyber Security Awareness Bot";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showTasksMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRemindersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showActivityLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startQuizMenuItem;
        private System.Windows.Forms.Label label1;
    }
}


