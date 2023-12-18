using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace AueSoftware_Estagio_TI
{
    public partial class Form1 : Form
    {
        private OleDbConnection conexao;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable Contatos;

        private System.Windows.Forms.Timer timer;


        public Form1()
        {
            InitializeComponent();
            string stringConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cbjea\\source\\repos\\AueSoftware_Estagio_TI\\AueSoftware_Estagio_TI\\BdAuE\\auebd.mdb";
            conexao = new OleDbConnection(stringConexao);
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            Contatos = new DataTable();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // 5 segundos
            timer.Tick += Timer_Tick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private int GetProximoCodContato()
        {
            try
            {
                using (OleDbCommand cmdSelectMaxCodContato = new OleDbCommand("SELECT MAX(CodContato) FROM Contatos", conexao))
                {
                    conexao.Open();
                    int maxCodContato = Convert.ToInt32(cmdSelectMaxCodContato.ExecuteScalar());
                    return maxCodContato + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1; // ou outro valor de erro
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sexo = (checkBoxMasculino.Checked) ? "M" : "F";

                int novoCodContato = GetProximoCodContato();

                string SQL = "INSERT INTO Contatos (CodContato, Nome, Sexo, Data, Cidade) VALUES (@CodContato, @Nome, @Sexo, @Data, @Cidade)";
                using (OleDbCommand cmd = new OleDbCommand(SQL, conexao))
                {
                    cmd.Parameters.Add("@CodContato", OleDbType.Integer).Value = novoCodContato;
                    cmd.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@Sexo", OleDbType.VarChar).Value = sexo;
                    cmd.Parameters.Add("@Data", OleDbType.Date).Value = DateTime.Now.ToString("MM/dd/yyyy");
                    cmd.Parameters.Add("@Cidade", OleDbType.VarWChar).Value = txtCidade.Text;

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Dados Cadastrados com Sucesso!");

                txtNome.Clear();
                txtCidade.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sexo = (checkBoxMasculino.Checked) ? "M" : "F";

                string SQL = "UPDATE Contatos SET Nome = @Nome, Sexo = @Sexo, Data = @Data, Cidade = @Cidade WHERE CodContato = @CodContato";
                using (OleDbCommand cmd = new OleDbCommand(SQL, conexao))
                {
                    cmd.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@Sexo", OleDbType.VarChar).Value = sexo;
                    cmd.Parameters.Add("@Data", OleDbType.Date).Value = DateTime.Now.ToString("MM/dd/yyyy");
                    cmd.Parameters.Add("@Cidade", OleDbType.VarWChar).Value = txtCidade.Text;
                    cmd.Parameters.Add("@CodContato", OleDbType.Integer).Value = GetProximoCodContato();

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Dados Atualizados com Sucesso!");

                txtNome.Clear();
                txtCidade.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sexo = (checkBoxMasculino.Checked) ? "M" : "F";

                string SQL = "DELETE FROM Contatos WHERE Nome = @Nome AND Sexo = @Sexo AND Cidade = @Cidade";
                using (OleDbCommand cmd = new OleDbCommand(SQL, conexao))
                {
                    cmd.Parameters.Add("@Nome", OleDbType.VarChar).Value = txtNome.Text;
                    cmd.Parameters.Add("@Sexo", OleDbType.VarChar).Value = sexo;
                    cmd.Parameters.Add("@Cidade", OleDbType.VarWChar).Value = txtCidade.Text;

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Contato excluído com sucesso!");

                txtNome.Clear();
                txtCidade.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Nome", 100);
            listView1.Columns.Add("Sexo", 50);
            listView1.Columns.Add("Data", 100);
            listView1.Columns.Add("Cidade", 100);

            listView1_SelectedIndexChanged(sender, e);

            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                listView1_SelectedIndexChanged(sender, e);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();

                string SQL = "SELECT Nome, Sexo, Data, Cidade FROM Contatos";
                using (OleDbCommand cmd = new OleDbCommand(SQL, conexao))
                {
                    conexao.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Nome"].ToString());
                        item.SubItems.Add(reader["Sexo"].ToString());
                        item.SubItems.Add(reader["Data"].ToString());
                        item.SubItems.Add(reader["Cidade"].ToString());

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                listView2.Items.Clear();

                
                StringBuilder analiseResultado = new StringBuilder();

                
                string SQL = "SELECT Cidade, " +
                             "SUM(IIF(Month(Data) = 1, 1, 0)) AS Janeiro, " +
                             "SUM(IIF(Month(Data) = 2, 1, 0)) AS Fevereiro, " +
                             "SUM(IIF(Month(Data) = 3, 1, 0)) AS Março, " +
                             "SUM(IIF(Month(Data) = 4, 1, 0)) AS Abril, " +
                             "SUM(IIF(Month(Data) = 5, 1, 0)) AS Maio, " +
                             "SUM(IIF(Month(Data) = 6, 1, 0)) AS Junho, " +
                             "SUM(IIF(Month(Data) = 7, 1, 0)) AS Julho, " +
                             "SUM(IIF(Month(Data) = 8, 1, 0)) AS Agosto, " +
                             "SUM(IIF(Month(Data) = 9, 1, 0)) AS Setembro, " +
                             "SUM(IIF(Month(Data) = 10, 1, 0)) AS Outubro, " +
                             "SUM(IIF(Month(Data) = 11, 1, 0)) AS Novembro, " +
                             "SUM(IIF(Month(Data) = 12, 1, 0)) AS Dezembro, " +
                             "COUNT(*) AS Total, " +
                             "SUM(IIF(Sexo = 'M', 1, 0)) AS Homens, " +
                             "SUM(IIF(Sexo = 'F', 1, 0)) AS Mulheres " +
                             "FROM Contatos " +
                             "GROUP BY Cidade " +
                             "HAVING SUM(IIF(Month(Data) >= 1, 1, 0)) > 0";

                using (OleDbCommand cmd = new OleDbCommand(SQL, conexao))
                {
                    conexao.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        analiseResultado.AppendLine($"Contatos em {reader["Cidade"]}:");
                        analiseResultado.AppendLine($". Janeiro: {reader["Janeiro"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Fevereiro: {reader["Fevereiro"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Março: {reader["Março"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Abril: {reader["Abril"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Maio: {reader["Maio"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Junho: {reader["Junho"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Julho: {reader["Julho"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Agosto: {reader["Agosto"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Setembro: {reader["Setembro"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Outubro: {reader["Outubro"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Novembro: {reader["Novembro"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Dezembro: {reader["Dezembro"]}, {reader["Homens"]} homens e {reader["Mulheres"]} mulher(es)");
                        analiseResultado.AppendLine($". Total: {reader["Total"]}");
                        analiseResultado.AppendLine();
                    }

                    reader.Close();
                }

                MessageBox.Show($"Exemplo de análise:\n\n{analiseResultado.ToString()}", "Análise dos contatos");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
