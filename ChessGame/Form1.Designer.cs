namespace ChessGame
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
            btn_NewGame = new Button();
            btn_Exit = new Button();
            btn_Concede = new Button();
            btn_Undo = new Button();
            SuspendLayout();
            // 
            // btn_NewGame
            // 
            btn_NewGame.Location = new Point(30, 20);
            btn_NewGame.Margin = new Padding(4, 5, 4, 5);
            btn_NewGame.Name = "btn_NewGame";
            btn_NewGame.Size = new Size(239, 70);
            btn_NewGame.TabIndex = 0;
            btn_NewGame.Text = "New Game";
            btn_NewGame.UseVisualStyleBackColor = true;
            btn_NewGame.Click += Btn_NewGame_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(30, 260);
            btn_Exit.Margin = new Padding(4, 5, 4, 5);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(239, 70);
            btn_Exit.TabIndex = 1;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += Btn_Exit_Click;
            // 
            // btn_Concede
            // 
            btn_Concede.Location = new Point(30, 100);
            btn_Concede.Margin = new Padding(4, 5, 4, 5);
            btn_Concede.Name = "btn_Concede";
            btn_Concede.Size = new Size(239, 70);
            btn_Concede.TabIndex = 2;
            btn_Concede.Text = "Concede";
            btn_Concede.UseVisualStyleBackColor = true;
            btn_Concede.Visible = false;
            btn_Concede.Click += btn_Concede_Click;
            // 
            // btn_Undo
            // 
            btn_Undo.Enabled = false;
            btn_Undo.Location = new Point(30, 180);
            btn_Undo.Margin = new Padding(4, 5, 4, 5);
            btn_Undo.Name = "btn_Undo";
            btn_Undo.Size = new Size(239, 70);
            btn_Undo.TabIndex = 3;
            btn_Undo.Text = "Undo";
            btn_Undo.UseVisualStyleBackColor = true;
            btn_Undo.Visible = false;
            btn_Undo.Click += btn_Undo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1946, 1226);
            Controls.Add(btn_Undo);
            Controls.Add(btn_Concede);
            Controls.Add(btn_Exit);
            Controls.Add(btn_NewGame);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Form1";
            Text = "ChessGame";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_NewGame;
        private Button btn_Exit;
        private Button btn_Concede;
        private Button btn_Undo;
    }
}
