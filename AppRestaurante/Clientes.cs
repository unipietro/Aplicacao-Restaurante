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


namespace AppRestaurante
{
    public partial class Clientes : Form
    {
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private BindingSource bindingSource = new BindingSource();

        public Clientes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                Conexao con = new Conexao();
                adpt = new MySqlDataAdapter("SELECT id_cliente, nome AS Nome, telefone AS Telefone, celular AS Celular, cep AS CEP, uf AS UF, cidade AS Cidade, bairro AS Bairro, logradouro AS Logradouro, n AS Numero, complemento AS Complemento, observacoes AS Observacoes FROM tabClientes", con.conec);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adpt);

                DataTable dat = new DataTable();
                adpt.Fill(dat);
                bindingSource.DataSource = dat;
                ClientesGridView.DataSource = bindingSource;
                ClientesGridView.Columns["id_cliente"].Visible = false;
                ClientesGridView.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ClientesGridView.Columns["Nome"].MinimumWidth = 100;
                ClientesGridView.Columns["Telefone"].Width = 90;
                ClientesGridView.Columns["Celular"].Width = 90;
                ClientesGridView.Columns["CEP"].Width = 70;
                ClientesGridView.Columns["UF"].Width = 30;
                ClientesGridView.Columns["Cidade"].Width = 100;
                ClientesGridView.Columns["Bairro"].Width = 100;
                ClientesGridView.Columns["Logradouro"].Width = 100;
                ClientesGridView.Columns["Numero"].Width = 100;
                ClientesGridView.Columns["Complemento"].Width = 100;
                ClientesGridView.Columns["Observacoes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ClientesGridView.Columns["Observacoes"].MinimumWidth = 100;
            }
            catch (Exception)
            {
                MessageBox.Show("Desculpe, mas ocorreu um erro ao buscar as informações no banco de dados.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
