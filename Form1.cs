using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
// comentario
namespace Controle_Clientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'naturaDataSet.clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.naturaDataSet.clientes);
            atualizarGrid();
        }
        private void limparCampos()
        {

            textBoxCodigo.Clear();
            textBoxNome.Clear();
            textBoxEndereco.Clear();
            textBoxBairro.Clear();
            textBoxCidade.Clear();
            textBoxCEP.Clear();
            textBoxEmail.Clear();
            textBoxCPF.Clear();
            textBoxIdentidade.Clear();
            textBoxParcelado.Clear();
        }

        private void atualizarGrid()
        {
            //Crio a estrutura da conexão com o banco e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "natura";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexão com o banco
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM `clientes` WHERE ativoCliente=1"; //Traz todo mundo da tabela autor
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dataGridView.Rows.Clear();//FAZ LIMPAR A TABELA

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();//FAZ UM CAST E CLONA A LINHA DA TABELA
                    row.Cells[0].Value = reader.GetInt32(0);//ID
                    row.Cells[1].Value = reader.GetString(1);//NOME
                    row.Cells[2].Value = reader.GetString(2);//ENDEREÇO
                    row.Cells[3].Value = reader.GetString(3);//BAIRRO
                    row.Cells[4].Value = reader.GetString(4);//CIDADE
                    row.Cells[5].Value = reader.GetString(5);//CEP
                    row.Cells[6].Value = reader.GetString(6);//EMAIL
                    row.Cells[7].Value = reader.GetString(7);//CPF
                    row.Cells[8].Value = reader.GetString(8);//IDENTIDADE
                    row.Cells[9].Value = reader.GetString(9);//VALOR
                    dataGridView.Rows.Add(row);//ADICIONO A LINHA NA TABELA
                }

                realizaConexacoBD.Close();
                //MessageBox.Show("Removido com sucesso"); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }


        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                limparCampos();
                dataGridView.CurrentRow.Selected = true;
                //preenche os textbox com as células da linha selecionada
                textBoxCodigo.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnId"].FormattedValue.ToString();
                textBoxNome.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnNome"].FormattedValue.ToString();
                textBoxEndereco.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnEndereco"].FormattedValue.ToString();
                textBoxBairro.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnBairro"].FormattedValue.ToString();
                textBoxCidade.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnCidade"].FormattedValue.ToString();
                textBoxCEP.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnCEP"].FormattedValue.ToString();
                textBoxCPF.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnCPF"].FormattedValue.ToString();
                textBoxIdentidade.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnIdentidade"].FormattedValue.ToString();
                textBoxEmail.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnEmail"].FormattedValue.ToString();
                textBoxParcelado.Text = dataGridView.Rows[e.RowIndex].Cells["ColumnValor"].FormattedValue.ToString();
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //Crio a estrutura da conexão com o banco e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "natura";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexão com o banco
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco
                //MessageBox.Show("Conexão Aberta!");

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "INSERT INTO `clientes` (`idCliente`, `nomeCliente`, `enderecoCliente`, `bairroCliente`, `cidadeCliente`, `cepCliente`, `emailCliente`, `identidadeCliente`, `cpfCliente`, `limiteCliente`, `ativoCliente`) VALUES (NULL, '" + textBoxNome.Text + "', '" + textBoxEndereco.Text + "', '" + textBoxBairro.Text + "', '" + textBoxCidade.Text + "', '" + textBoxCEP.Text + "', '" + textBoxEmail.Text + "', '" + textBoxIdentidade.Text + "', '" + textBoxCPF.Text + "', '" + textBoxParcelado.Text +"', '1');";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Inserido com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            //Crio a estrutura da conexão com o banco e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "natura";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexão com o banco
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco
                //MessageBox.Show("Conexão Aberta!");

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = " UPDATE `clientes` SET `ativoCliente` = '0' WHERE `idCliente` = " + textBoxCodigo.Text + ";";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Apagado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            //Crio a estrutura da conexão com o banco e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "natura";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexão com o banco
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco
                //MessageBox.Show("Conexão Aberta!");

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "UPDATE `clientes` SET `nomeCliente` = '"+ textBoxNome.Text +"', `enderecoCliente` = '"+ textBoxEndereco.Text + "', `bairroCliente` = '" + textBoxBairro.Text + "', `cidadeCliente` = '" + textBoxCidade.Text + "', `cepCliente` = '" + textBoxCEP.Text +"', `emailCliente` = '"+ textBoxEmail.Text +"', `identidadeCliente` = '" + textBoxIdentidade.Text +"', `limiteCliente` = '" + textBoxParcelado.Text +"' WHERE `idCliente` = " + textBoxCodigo.Text + ";";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Salvo com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }
    }
    
}
