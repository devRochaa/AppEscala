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

            lst_acolitos.View = View.Details;
            lst_acolitos.LabelEdit = true;
            lst_acolitos.AllowColumnReorder = true;
            lst_acolitos.FullRowSelect = true;
            lst_acolitos.GridLines = true;

            lst_acolitos.Columns.Add("Nome", 155, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Segunda", 70, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Terça", 70, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Quarta", 70, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Quinta", 70, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Sexta", 70, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Sábado", 70, HorizontalAlignment.Left);
            lst_acolitos.Columns.Add("Domingo", 70, HorizontalAlignment.Left);

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
                string sql = "SELECT a.nome, s.dia_semana, t.turno, d.id_dia_semana " +
                    "FROM acolitos AS a " +
                    "LEFT JOIN disponibilidade AS d ON a.id = d.id_acolito " +
                    "RIGHT JOIN dias_semana AS s ON d.id_dia_semana = s.id " +
                    "RIGHT JOIN turno AS t ON d.id_turno = t.id " +
                    "WHERE a.nome LIKE " + q + " ORDER BY s.id" ;
                Conexao.Open();
                MySqlCommand comando = new MySqlCommand( sql, Conexao);
                
                MySqlDataReader reader = comando.ExecuteReader();
                lst_acolitos.Items.Clear();

                while (reader.Read()) 
                {
                    string nome = reader.GetString(0);
                    string turno = reader.GetString(2);
                    int id_dia = reader.GetInt32(3);
                    
                    string[] row =
                    {
                        reader.GetString(0),
                        
                    };

                    for (int i = 2; i < 7; i++)
                    {
                        if (id_dia == i)
                        {
                            row[i] = turno;
                        }
                    }

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
