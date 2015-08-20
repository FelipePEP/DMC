using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form0 : Form
    {
        private List<Personagem> ListaPC = new List<Personagem>();
        public Form0()
        {
            InitializeComponent();

            ListaPC = carregarListaPC();

            foreach (Personagem p in ListaPC)
            {
                Form1 ficha = new Form1(p);
                ficha.Text = p.jogador;
                ficha.TopLevel = false;
                ficha.Show();
                this.Controls.Add(ficha);
            }

            
        }
        private List<int[]> carregarSlots(Personagem P)
        {
            string sql = "select Conhecido, Usado from SlotsMagicos where personagemId = " + P.id + " order by circuloId";
            SqlConnection con = new SqlConnection("Data Source=PEP-PC;Initial Catalog=DMC;Integrated Security=True"); 
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open(); 
            
            List<int[]> slots = new List<int[]>();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                int[] item = new int[2];
                item[0] = Convert.ToInt16(reader[0]);
                item[1] = Convert.ToInt16(reader[1]);
                slots.Add(item);
            }
            con.Close();
            return slots;
            
        }
        private List<Personagem> carregarListaPC()
        {

            string sql = "select * from personagem";
            SqlConnection con = new SqlConnection("Data Source=PEP-PC;Initial Catalog=DMC;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Personagem P = new Personagem();
                    P.id = Convert.ToInt16(reader[0]);
                    P.nome = reader[1].ToString();
                    P.jogador = reader[2].ToString();
                    P.classe = reader[3].ToString();
                    P.raca = reader[4].ToString();
                    P.hp[0] = Convert.ToInt16(reader[5]);
                    P.hp[1] = Convert.ToInt16(reader[6]);
                    P.sorte = Convert.ToInt16(reader[7]);
                    P.inspiracao = Convert.ToInt16(reader[8]);
                    P.xp = Convert.ToInt16(reader[9]);
                    P.exaustao = Convert.ToInt16(reader[10]);
                    P.sorteAtual = Convert.ToInt16(reader[11]);

                    List<int[]> slots = carregarSlots(P);

                    for(int i =0; i < slots.Count; i++){

                        P.slots[i] = slots[i][0];
                        P.slotsUsados[i] = slots[i][1];

                    }

                    this.ListaPC.Add(P);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally { con.Close(); }

            return ListaPC;
        }
    }
}
