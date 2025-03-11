using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEscala.Helpers;
using AppEscala.Models;
using MySql.Data.MySqlClient;
using static AppEscala.Helpers.Database;

namespace AppEscala
{
    public partial class form_editar : Form
    {
        private Database db;
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";
        public int? id_missa { get; set; }
        public form_editar()
        {
            InitializeComponent();
        }

        private void form_editar_Load(object sender, EventArgs e)
        {
            db = new Database();
            db.Initialize();
            for (int i = 0; i <= 15; i++)
            {
                cmb_quant.Items.Add(i);
            }
            combobox_igreja();

            carregar_missaSelecionada();
        }

        public class Item
        {
            public string Display { get; set; } // O texto visível
            public int Value { get; set; } // O valor oculto

            public override string ToString()
            {
                return Display; // Exibe apenas o texto no ComboBox
            }
        }

        private void combobox_igreja()
        {
            var listaIgreja = db.SelectAllIgreja();
            foreach (var igreja in listaIgreja)
            {
                cmb_igrejas.Items.Add(new Item { Display = igreja.nome, Value = igreja.id });
                
            }
        }

        DateTime dataConvertida;
        string hora;
        string igreja;
        int qntAntiga = -1;
        string descAntiga;
        private void carregar_missaSelecionada()
        {

            MissasDadosCompletos missaSelecionada = db.SelectMissa(id_missa);
            string data_bruta = missaSelecionada.Data;
            if (DateTime.TryParse(data_bruta, out dataConvertida))
            {
                dtp_missa.Value = dataConvertida;
            } 
            else
            {
                MessageBox.Show("Não foi possível converter a data");
            }
            if(missaSelecionada.Horario.Trim() != "") { 
            hora = missaSelecionada.Horario;
            txt_hora1.Text = missaSelecionada.Horario.Substring(0, 2);
            txt_hora2.Text = missaSelecionada.Horario.Substring(3);
            }
            igreja = missaSelecionada.Igreja;

            foreach (Item item in cmb_igrejas.Items)
            {
                
                if ((int)item.Value == missaSelecionada.Id_igreja)
                {
                    cmb_igrejas.SelectedItem = item;
                    break;
                }
            }
            
            cmb_quant.SelectedIndex = missaSelecionada.Qnt_acolitos;
            qntAntiga = missaSelecionada.Qnt_acolitos;

            txt_desc.Text = missaSelecionada.Descricao;
            descAntiga = missaSelecionada.Descricao;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string data_nova = dtp_missa.Value.ToString().Substring(0, 10).Trim();
            string hora_nova = txt_hora1.Text + ":" + txt_hora2.Text;
            bool foiAlterado = false;
            if (igreja != cmb_igrejas.SelectedItem.ToString() && cmb_igrejas.SelectedItem.ToString() != null)
            {
                foiAlterado = true;
            }
            
            if (hora.Substring(0, 2) != txt_hora1.Text || hora.Substring(3) != txt_hora2.Text)
            {
                if (txt_hora1.TextLength == 0)
                {
                    txt_hora1.Text = "00";
                }
                if (txt_hora2.TextLength == 0)
                {
                    txt_hora2.Text = "00";
                }
                hora_nova = txt_hora1.Text + ":" + txt_hora2.Text;
                foiAlterado = true;
            }
            if (dataConvertida != dtp_missa.Value)
            {
                foiAlterado = true;
            }
            if (descAntiga != txt_desc.Text) foiAlterado = true;
            if (qntAntiga != cmb_quant.SelectedIndex) foiAlterado = true;

            if (foiAlterado == true) 
            {
                Item selectedItem = (Item)cmb_igrejas.SelectedItem;
                int id_igreja = selectedItem.Value;
                int idMissa = id_missa.Value;
                MissasC dadosNovaMissa = new MissasC {Id = idMissa, Data = data_nova, Horario = hora_nova, Id_igreja = id_igreja, Qnt_acolitos = cmb_quant.SelectedIndex, Descricao = txt_desc.Text  
                };
                db.UpdateMissa(id_missa, dadosNovaMissa);
                MessageBox.Show("A missa foi editada");
                DialogResult = DialogResult.OK; // Define o resultado do diálogo
                this.Close();
            }
        //        try
        //        {
        //        int conn_atv = 0;
        //        Conexao = new MySqlConnection(data_source);
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = Conexao;

        //        if (igreja != cmb_igrejas.SelectedItem.ToString() && cmb_igrejas.SelectedItem.ToString() != null)
        //        {
                    
        //            cmd.CommandText = "UPDATE missas SET id_igreja = " +
        //                    "(SELECT id FROM igreja WHERE nome = @igreja_nova) " +
        //                    "WHERE id = @id_missa";
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("@igreja_nova", cmb_igrejas.SelectedItem);
        //            cmd.Parameters.AddWithValue("@id_missa", id_missa);

        //            Conexao.Open();
        //            conn_atv = 1;
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show($"Igreja Atualizada");
        //        }

        //        if (hora.Substring(0, 2) != txt_hora1.Text || hora.Substring(3) != txt_hora2.Text)
        //        {
        //            if (txt_hora1.TextLength == 0)
        //            {
        //                txt_hora1.Text = "00";
        //            }
        //            if (txt_hora2.TextLength == 0)
        //            {
        //                txt_hora2.Text = "00";
        //            }
        //            hora_nova = txt_hora1.Text + ":" + txt_hora2.Text;
                    
        //            cmd.CommandText = "UPDATE missas SET horario = @horario_novo " +
        //                "WHERE id = @id_missa";
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("@horario_novo", hora_nova);
        //            cmd.Parameters.AddWithValue("@id_missa", id_missa);
        //            if(conn_atv == 0)
        //            {
        //            Conexao.Open();
        //             conn_atv = 1;
        //            }
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show($"Hora Atualizada");
        //        }
            

        //        if(dataConvertida != dtp_missa.Value)
        //        {
        //            string data_nova = dtp_missa.Value.ToString();
                    
        //            cmd.CommandText = "UPDATE missas SET data = @data_nova " +
        //                "WHERE id = @id_missa";
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("@data_nova", data_nova);
        //            cmd.Parameters.AddWithValue("@id_missa", id_missa);
        //            if(conn_atv == 0)
        //            {
        //                Conexao.Open();
        //                conn_atv = 1;
        //            }
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show($"Data Atualizada");
        //        }
        //        if (conn_atv == 0) 
        //        {
        //            MessageBox.Show($"Você não alterou nenhuma informação!");
        //            return;
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show($"Erro MySQL: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro geral: {ex.Message}");
        //    }
        //    finally
        //    {
        //        if (Conexao != null && Conexao.State == ConnectionState.Open)
        //        {
        //            Conexao.Close();
        //        }
        //    }
        }

       
    }
}
