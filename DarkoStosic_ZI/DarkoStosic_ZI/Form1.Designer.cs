
namespace DarkoStosic_ZI
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.XPartTbx = new System.Windows.Forms.TextBox();
            this.YXorBits = new System.Windows.Forms.TextBox();
            this.YPartTbx = new System.Windows.Forms.TextBox();
            this.ZPartTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.XVote = new System.Windows.Forms.NumericUpDown();
            this.ZVote = new System.Windows.Forms.NumericUpDown();
            this.YVote = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.XXorBits = new System.Windows.Forms.TextBox();
            this.ZXorBits = new System.Windows.Forms.TextBox();
            this.OutputBtn = new System.Windows.Forms.Button();
            this.EncodeBtn = new System.Windows.Forms.Button();
            this.DecodeBtn = new System.Windows.Forms.Button();
            this.Load_Key = new System.Windows.Forms.Button();
            this.VoteBtn = new System.Windows.Forms.Button();
            this.LoadXorBits = new System.Windows.Forms.Button();
            this.Key = new System.Windows.Forms.Label();
            this.LoadWholeKeyTb = new System.Windows.Forms.TextBox();
            this.LoadWholeKey = new System.Windows.Forms.Button();
            this.incTbx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.XVote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZVote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YVote)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X part key:";
            // 
            // XPartTbx
            // 
            this.XPartTbx.Location = new System.Drawing.Point(87, 35);
            this.XPartTbx.Name = "XPartTbx";
            this.XPartTbx.Size = new System.Drawing.Size(100, 20);
            this.XPartTbx.TabIndex = 2;
            // 
            // YXorBits
            // 
            this.YXorBits.Location = new System.Drawing.Point(87, 178);
            this.YXorBits.Name = "YXorBits";
            this.YXorBits.Size = new System.Drawing.Size(100, 20);
            this.YXorBits.TabIndex = 3;
            // 
            // YPartTbx
            // 
            this.YPartTbx.Location = new System.Drawing.Point(87, 60);
            this.YPartTbx.Name = "YPartTbx";
            this.YPartTbx.Size = new System.Drawing.Size(100, 20);
            this.YPartTbx.TabIndex = 5;
            // 
            // ZPartTbx
            // 
            this.ZPartTbx.Location = new System.Drawing.Point(87, 88);
            this.ZPartTbx.Name = "ZPartTbx";
            this.ZPartTbx.Size = new System.Drawing.Size(100, 20);
            this.ZPartTbx.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y part key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Z part key:";
            // 
            // XVote
            // 
            this.XVote.Location = new System.Drawing.Point(107, 121);
            this.XVote.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.XVote.Name = "XVote";
            this.XVote.Size = new System.Drawing.Size(35, 20);
            this.XVote.TabIndex = 9;
            // 
            // ZVote
            // 
            this.ZVote.Location = new System.Drawing.Point(235, 121);
            this.ZVote.Maximum = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.ZVote.Name = "ZVote";
            this.ZVote.Size = new System.Drawing.Size(35, 20);
            this.ZVote.TabIndex = 10;
            // 
            // YVote
            // 
            this.YVote.Location = new System.Drawing.Point(171, 121);
            this.YVote.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.YVote.Name = "YVote";
            this.YVote.Size = new System.Drawing.Size(35, 20);
            this.YVote.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Voting bits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Z:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "X xor bits:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Y xor bits:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Z xor bits:";
            // 
            // XXorBits
            // 
            this.XXorBits.Location = new System.Drawing.Point(87, 152);
            this.XXorBits.Name = "XXorBits";
            this.XXorBits.Size = new System.Drawing.Size(100, 20);
            this.XXorBits.TabIndex = 19;
            // 
            // ZXorBits
            // 
            this.ZXorBits.Location = new System.Drawing.Point(87, 206);
            this.ZXorBits.Name = "ZXorBits";
            this.ZXorBits.Size = new System.Drawing.Size(100, 20);
            this.ZXorBits.TabIndex = 20;
            // 
            // OutputBtn
            // 
            this.OutputBtn.Location = new System.Drawing.Point(12, 235);
            this.OutputBtn.Name = "OutputBtn";
            this.OutputBtn.Size = new System.Drawing.Size(75, 41);
            this.OutputBtn.TabIndex = 24;
            this.OutputBtn.Text = "Output folder";
            this.OutputBtn.UseVisualStyleBackColor = true;
            this.OutputBtn.Click += new System.EventHandler(this.OutputBtn_Click);
            // 
            // EncodeBtn
            // 
            this.EncodeBtn.Location = new System.Drawing.Point(93, 244);
            this.EncodeBtn.Name = "EncodeBtn";
            this.EncodeBtn.Size = new System.Drawing.Size(75, 23);
            this.EncodeBtn.TabIndex = 25;
            this.EncodeBtn.Text = "Encode";
            this.EncodeBtn.UseVisualStyleBackColor = true;
            this.EncodeBtn.Click += new System.EventHandler(this.EncodeBtn_Click);
            // 
            // DecodeBtn
            // 
            this.DecodeBtn.Location = new System.Drawing.Point(174, 244);
            this.DecodeBtn.Name = "DecodeBtn";
            this.DecodeBtn.Size = new System.Drawing.Size(75, 23);
            this.DecodeBtn.TabIndex = 26;
            this.DecodeBtn.Text = "Decode";
            this.DecodeBtn.UseVisualStyleBackColor = true;
            this.DecodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // Load_Key
            // 
            this.Load_Key.Location = new System.Drawing.Point(195, 68);
            this.Load_Key.Name = "Load_Key";
            this.Load_Key.Size = new System.Drawing.Size(75, 40);
            this.Load_Key.TabIndex = 27;
            this.Load_Key.Text = "Load Key Parts";
            this.Load_Key.UseVisualStyleBackColor = true;
            this.Load_Key.Click += new System.EventHandler(this.Load_Key_Click);
            // 
            // VoteBtn
            // 
            this.VoteBtn.Location = new System.Drawing.Point(195, 150);
            this.VoteBtn.Name = "VoteBtn";
            this.VoteBtn.Size = new System.Drawing.Size(75, 23);
            this.VoteBtn.TabIndex = 28;
            this.VoteBtn.Text = "Load votes";
            this.VoteBtn.UseVisualStyleBackColor = true;
            this.VoteBtn.Click += new System.EventHandler(this.VoteBtn_Click);
            // 
            // LoadXorBits
            // 
            this.LoadXorBits.Location = new System.Drawing.Point(195, 204);
            this.LoadXorBits.Name = "LoadXorBits";
            this.LoadXorBits.Size = new System.Drawing.Size(75, 23);
            this.LoadXorBits.TabIndex = 29;
            this.LoadXorBits.Text = "Load xor bits";
            this.LoadXorBits.UseVisualStyleBackColor = true;
            this.LoadXorBits.Click += new System.EventHandler(this.LoadXorBits_Click);
            // 
            // Key
            // 
            this.Key.AutoSize = true;
            this.Key.Location = new System.Drawing.Point(12, 12);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(28, 13);
            this.Key.TabIndex = 30;
            this.Key.Text = "Key:";
            // 
            // LoadWholeKeyTb
            // 
            this.LoadWholeKeyTb.Location = new System.Drawing.Point(87, 9);
            this.LoadWholeKeyTb.Name = "LoadWholeKeyTb";
            this.LoadWholeKeyTb.Size = new System.Drawing.Size(100, 20);
            this.LoadWholeKeyTb.TabIndex = 31;
            // 
            // LoadWholeKey
            // 
            this.LoadWholeKey.Location = new System.Drawing.Point(195, 9);
            this.LoadWholeKey.Name = "LoadWholeKey";
            this.LoadWholeKey.Size = new System.Drawing.Size(75, 23);
            this.LoadWholeKey.TabIndex = 32;
            this.LoadWholeKey.Text = "Load Key";
            this.LoadWholeKey.UseVisualStyleBackColor = true;
            this.LoadWholeKey.Click += new System.EventHandler(this.LoadWholeKey_Click);
            // 
            // incTbx
            // 
            this.incTbx.Location = new System.Drawing.Point(119, 273);
            this.incTbx.Name = "incTbx";
            this.incTbx.Size = new System.Drawing.Size(100, 20);
            this.incTbx.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.incTbx);
            this.Controls.Add(this.LoadWholeKey);
            this.Controls.Add(this.LoadWholeKeyTb);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.LoadXorBits);
            this.Controls.Add(this.VoteBtn);
            this.Controls.Add(this.Load_Key);
            this.Controls.Add(this.DecodeBtn);
            this.Controls.Add(this.EncodeBtn);
            this.Controls.Add(this.OutputBtn);
            this.Controls.Add(this.ZXorBits);
            this.Controls.Add(this.XXorBits);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.YVote);
            this.Controls.Add(this.ZVote);
            this.Controls.Add(this.XVote);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ZPartTbx);
            this.Controls.Add(this.YPartTbx);
            this.Controls.Add(this.YXorBits);
            this.Controls.Add(this.XPartTbx);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ZastitaInformacija";
            ((System.ComponentModel.ISupportInitialize)(this.XVote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZVote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YVote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox XPartTbx;
        private System.Windows.Forms.TextBox YXorBits;
        private System.Windows.Forms.TextBox YPartTbx;
        private System.Windows.Forms.TextBox ZPartTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown XVote;
        private System.Windows.Forms.NumericUpDown ZVote;
        private System.Windows.Forms.NumericUpDown YVote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox XXorBits;
        private System.Windows.Forms.TextBox ZXorBits;
        private System.Windows.Forms.Button OutputBtn;
        private System.Windows.Forms.Button EncodeBtn;
        private System.Windows.Forms.Button DecodeBtn;
        private System.Windows.Forms.Button Load_Key;
        private System.Windows.Forms.Button VoteBtn;
        private System.Windows.Forms.Button LoadXorBits;
        private System.Windows.Forms.Label Key;
        private System.Windows.Forms.TextBox LoadWholeKeyTb;
        private System.Windows.Forms.Button LoadWholeKey;
        private System.Windows.Forms.TextBox incTbx;
    }
}

