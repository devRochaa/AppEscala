using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.StyledXmlParser.Jsoup.Nodes;
using MySql.Data.MySqlClient;

namespace AppEscala
{
    public partial class userAcolitos : UserControl
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";

        public userAcolitos()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void acolitos_Load(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "'%" + txtPesquisa.Text + "%'";

                Conexao = new MySqlConnection(data_source);
                string sql = "SELECT a.nome, d.seg, d.ter, d.qua, d.qui, d.sex, d.sab, d.dom " +
                    "FROM acolitos AS a INNER JOIN disponibilidade AS d ON a.id = d.id_acolito" +
                    " WHERE a.nome LIKE "+ q ;
                Conexao.Open();
                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                
                MySqlDataReader reader = comando.ExecuteReader();
                lst_acolitos.Clear();

                while (reader.Read()) 
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                    };
                var linha_listview = new ListViewItem(row); 
                    lst_acolitos.Items.Add(linha_listview);
                }

                MessageBox.Show("Deu tudo certo!");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }   
        }
    }
}
