namespace AueSoftware_Estagio_TI
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
            label1 = new Label();
            labelSexo = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            txtCidade = new TextBox();
            checkBoxMasculino = new CheckBox();
            checkBoxFeminino = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(624, 61);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // labelSexo
            // 
            labelSexo.AutoSize = true;
            labelSexo.Location = new Point(624, 96);
            labelSexo.Name = "labelSexo";
            labelSexo.Size = new Size(41, 20);
            labelSexo.TabIndex = 0;
            labelSexo.Text = "Sexo";
            labelSexo.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(624, 128);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 0;
            label3.Text = "Cidade";
            label3.Click += label3_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(680, 54);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(262, 27);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += textBox1_TextChanged;
            // 
            // txtCidade
            // 
            txtCidade.Location = new Point(680, 125);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(262, 27);
            txtCidade.TabIndex = 1;
            txtCidade.TextChanged += textBox3_TextChanged;
            // 
            // checkBoxMasculino
            // 
            checkBoxMasculino.AutoSize = true;
            checkBoxMasculino.Location = new Point(680, 96);
            checkBoxMasculino.Name = "checkBoxMasculino";
            checkBoxMasculino.Size = new Size(44, 24);
            checkBoxMasculino.TabIndex = 2;
            checkBoxMasculino.Text = "M";
            checkBoxMasculino.UseVisualStyleBackColor = true;
            checkBoxMasculino.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBoxFeminino
            // 
            checkBoxFeminino.AutoSize = true;
            checkBoxFeminino.Location = new Point(723, 96);
            checkBoxFeminino.Name = "checkBoxFeminino";
            checkBoxFeminino.Size = new Size(38, 24);
            checkBoxFeminino.TabIndex = 2;
            checkBoxFeminino.Text = "F";
            checkBoxFeminino.UseVisualStyleBackColor = true;
            checkBoxFeminino.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(680, 173);
            button1.Name = "button1";
            button1.Size = new Size(81, 26);
            button1.TabIndex = 3;
            button1.Text = "Inserir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(767, 173);
            button2.Name = "button2";
            button2.Size = new Size(84, 26);
            button2.TabIndex = 3;
            button2.Text = "Alterar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(857, 173);
            button3.Name = "button3";
            button3.Size = new Size(85, 26);
            button3.TabIndex = 3;
            button3.Text = "Excluir";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(28, 25);
            listView1.Name = "listView1";
            listView1.Size = new Size(560, 294);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // listView2
            // 
            listView2.Location = new Point(28, 336);
            listView2.Name = "listView2";
            listView2.Size = new Size(914, 150);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(28, 492);
            button4.Name = "button4";
            button4.Size = new Size(515, 39);
            button4.TabIndex = 5;
            button4.Text = "Contar nº de contatos por cidade";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(981, 577);
            Controls.Add(button4);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBoxFeminino);
            Controls.Add(checkBoxMasculino);
            Controls.Add(txtCidade);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(labelSexo);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contatos AuE Software";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelSexo;
        private Label label3;
        private TextBox txtNome;
        private TextBox txtCidade;
        private CheckBox checkBoxMasculino;
        private CheckBox checkBoxFeminino;
        private Button button1;
        private Button button2;
        private Button button3;
        private ListView listView1;
        private ListView listView2;
        private Button button4;
    }
}
