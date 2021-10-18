
namespace MusicPlayer_QuestionOne
{
    partial class MusicPlayer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            this.WindowsMusicPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.ButtonFirst = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.ButtonLast = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.currentSongTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMusicPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // WindowsMusicPlayer
            // 
            this.WindowsMusicPlayer.Enabled = true;
            this.WindowsMusicPlayer.Location = new System.Drawing.Point(12, 269);
            this.WindowsMusicPlayer.Name = "WindowsMusicPlayer";
            this.WindowsMusicPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WindowsMusicPlayer.OcxState")));
            this.WindowsMusicPlayer.Size = new System.Drawing.Size(587, 244);
            this.WindowsMusicPlayer.TabIndex = 0;
            // 
            // ListBox
            // 
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(183, 12);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(416, 199);
            this.ListBox.TabIndex = 1;
            // 
            // ButtonFirst
            // 
            this.ButtonFirst.Location = new System.Drawing.Point(12, 63);
            this.ButtonFirst.Name = "ButtonFirst";
            this.ButtonFirst.Size = new System.Drawing.Size(161, 44);
            this.ButtonFirst.TabIndex = 2;
            this.ButtonFirst.Text = "First Song";
            this.ButtonFirst.UseVisualStyleBackColor = true;
            this.ButtonFirst.Click += new System.EventHandler(this.ButtonFirst_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(12, 113);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(161, 44);
            this.ButtonNext.TabIndex = 3;
            this.ButtonNext.Text = "Next";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(12, 163);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(161, 44);
            this.ButtonPrevious.TabIndex = 4;
            this.ButtonPrevious.Text = "Previous";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // ButtonLast
            // 
            this.ButtonLast.Location = new System.Drawing.Point(12, 215);
            this.ButtonLast.Name = "ButtonLast";
            this.ButtonLast.Size = new System.Drawing.Size(161, 44);
            this.ButtonLast.TabIndex = 5;
            this.ButtonLast.Text = "Last Song";
            this.ButtonLast.UseVisualStyleBackColor = true;
            this.ButtonLast.Click += new System.EventHandler(this.ButtonLast_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(12, 13);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(161, 44);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "Add Song";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // currentSongTextBox
            // 
            this.currentSongTextBox.Location = new System.Drawing.Point(183, 229);
            this.currentSongTextBox.Name = "currentSongTextBox";
            this.currentSongTextBox.Size = new System.Drawing.Size(416, 20);
            this.currentSongTextBox.TabIndex = 7;
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 523);
            this.Controls.Add(this.currentSongTextBox);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonLast);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonFirst);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.WindowsMusicPlayer);
            this.Name = "MusicPlayer";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.WindowsMusicPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer WindowsMusicPlayer;
        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.Button ButtonFirst;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.Button ButtonLast;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox currentSongTextBox;
    }
}

