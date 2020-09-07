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

namespace Natura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            atualizarGrid();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void limparCampos()
        {
            textBoxNome.Clear();
            textBoxEndereco.Clear();
            textBoxBairro.Clear();
            textBoxCidade.Clear();
            textBoxCEP.Clear();
            textBoxIdentidade.Clear();
            textBoxCPF.Clear();
            textBoxLimite.Clear();
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
                    row.Cells[2].Value = reader.GetString(2);//Endereço
                    row.Cells[3].Value = reader.GetString(3);//Bairro
                    row.Cells[4].Value = reader.GetString(4);//Cidade
                    row.Cells[5].Value = reader.GetString(5);//CEP
                    row.Cells[6].Value = reader.GetString(6);//Identidade
                    row.Cells[7].Value = reader.GetString(7);//CPF
                    row.Cells[8].Value = reader.GetString(8);//Limite
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            //Crio a estrutura da conexão com o banco e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "Natura";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            //Realizo a conexão com o banco
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco
                //MessageBox.Show("Conexão Aberta!");
                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "INSERT INTO `clientes` (`idCliente`, `nomeCliente`, `enderecoCliente`, `bairroCliente`, `cidadeCliente`, `cepCliente`, `identidadeCliente`, `cpfCliente`, `limiteCliente`) " + 
                    "VALUES( '', '" + textBoxNome.Text + "', '" + textBoxEndereco.Text + "', '" + textBoxBairro.Text + "', '" + textBoxCidade.Text + "', '" + textBoxCEP.Text + "', '" + textBoxIdentidade.Text + "', '" + textBoxCPF.Text + "', '" + textBoxLimite.Text + "');";
                Console.WriteLine(comandoMySql.CommandText);
                comandoMySql.ExecuteNonQuery();
                
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


}
