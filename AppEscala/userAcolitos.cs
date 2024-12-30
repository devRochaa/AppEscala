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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppEscala
{

    public partial class userAcolitos : UserControl
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";

        public userAcolitos()
        {
            InitializeComponent();
          
            dgv_acolitos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;            
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
                dgv_acolitos.Rows.Clear();
                string[] row = new string[8];
                while (reader.Read()) 
                {
                    string nome = reader.GetString(0);
                    string turno = reader.GetString(2);
                    int id_dia = reader.GetInt32(3);
                    
                    row[0] = reader.GetString(0);


                    for (int i = 0; i < 8; i++)
                    {
                        
                        if (id_dia == i)
                        {
                            row[i] = string.IsNullOrEmpty(row[i]) ? turno : $"{row[i]}\n{turno}";
                        }
                    }
                    

                    
                }
                    var linha_listview = new ListViewItem(row);
                dgv_acolitos.Rows.Add(row);
                if (string.IsNullOrEmpty(row[0]))
                {
                    MessageBox.Show("Não foi encontrado nenhum nome relacionado.");
                }
                
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
