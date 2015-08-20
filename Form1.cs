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
    public partial class Form1 : Form
    {
        private Personagem personagem = new Personagem();

        public Form1(Personagem p)
        {
            InitializeComponent();
            personagem = p;
            PreencherFicha(personagem);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void PreencherFicha(Personagem p)
        {
            lblPc1.Text = p.nome;
            pc1hp.Text = p.hp[1].ToString();

            bxSortePc1.SelectedIndex = p.sorteAtual;
            bxInspiraPc1.SelectedIndex = p.inspiracao;
            bxExaustaoPc1.SelectedIndex = p.exaustao;

            lblSlotMax1Pc1.Text = p.slots[0].ToString();
            lblSlotMax2Pc1.Text = p.slots[1].ToString();
            lblSlotMax3Pc1.Text = p.slots[2].ToString();
            lblSlotMax4Pc1.Text = p.slots[3].ToString();
            lblSlotMax5Pc1.Text = p.slots[4].ToString();
            lblSlotMax6Pc1.Text = p.slots[5].ToString();
            lblSlotMax7Pc1.Text = p.slots[6].ToString();
            lblSlotMax8Pc1.Text = p.slots[7].ToString();
            lblSlotMax9Pc1.Text = p.slots[8].ToString();

            bxXP1.SelectedIndex = p.xp;

            comboBox1.SelectedIndex = p.slotsUsados[0];
            comboBox2.SelectedIndex = p.slotsUsados[1];
            comboBox3.SelectedIndex = p.slotsUsados[2];
            comboBox4.SelectedIndex = p.slotsUsados[3];
            comboBox5.SelectedIndex = p.slotsUsados[4];
            comboBox6.SelectedIndex = p.slotsUsados[5];
            comboBox7.SelectedIndex = p.slotsUsados[6];
            comboBox8.SelectedIndex = p.slotsUsados[7];
            comboBox9.SelectedIndex = p.slotsUsados[8];
        }
        #region FUNCOES

        public static int atualizaSlotMagia(Personagem pc, int circulo, int pretendido)
        {
            if (pc.slots[circulo - 1] < pretendido)
            {
                MessageBox.Show("Slots esgotados!");
                return pc.slots[circulo - 1];
            }
            else
            {
                pc.slotsUsados[circulo - 1] = pretendido;
                return pretendido;
            }
        }

        public static int atualizarHP(Personagem pc, int num, bool temp)
        {
            pc.hp[1] += num;

            if (pc.hp[1] > pc.hp[0] && temp == false)
            {
                pc.hp[1] = pc.hp[0];
                return pc.hp[0];
            }
            return pc.hp[1];
        }

        public void descansoLongo(Personagem pc)
        {

            pc1hp.Text = (pc.hp[0]).ToString();
            pc.hp[1] = pc.hp[0];
            pc1hpalterar.Text = "";
            bxExaustaoPc1.SelectedIndex = (bxExaustaoPc1.SelectedIndex - 1);
            pc.exaustao--;
            for (var i = 0; i < 9; i++) { pc.slotsUsados[i] = 0; }


            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            if (bxSortePc1.SelectedIndex < personagem.sorte) bxSortePc1.SelectedIndex = personagem.sorte;
            MessageBox.Show("Descanso longo realizado");
        }


        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(pc1hpalterar.Text);
            bool temp = false;
            if (checkBox1.Checked == true) { temp = true; }
            pc1hp.Text = (atualizarHP(personagem, y, temp)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(pc1hpalterar.Text);
            bool temp = false;
            pc1hp.Text = (atualizarHP(personagem, y * (-1), temp)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            descansoLongo(personagem);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox1.Text);
            comboBox1.Text = (atualizaSlotMagia(personagem, 1, pretendido)).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox2.Text);
            comboBox2.Text = (atualizaSlotMagia(personagem, 2, pretendido)).ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox3.Text);
            comboBox3.Text = (atualizaSlotMagia(personagem, 3, pretendido)).ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox4.Text);
            comboBox4.Text = (atualizaSlotMagia(personagem, 4, pretendido)).ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox5.Text);
            comboBox5.Text = (atualizaSlotMagia(personagem, 5, pretendido)).ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox6.Text);
            comboBox6.Text = (atualizaSlotMagia(personagem, 6, pretendido)).ToString();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox7.Text);
            comboBox7.Text = (atualizaSlotMagia(personagem, 7, pretendido)).ToString();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox8.Text);
            comboBox8.Text = (atualizaSlotMagia(personagem, 8, pretendido)).ToString();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox9.Text);
            comboBox9.Text = (atualizaSlotMagia(personagem, 9, pretendido)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string sql = "UPDATE Personagem set " +                
                " hpatual =" + pc1hp.Text.ToString() +
                ", inpiracao =" + bxInspiraPc1.SelectedIndex.ToString() +
                ", xp =" + bxXP1.SelectedIndex.ToString() +
                ", exaustao =" + bxExaustaoPc1.SelectedIndex.ToString() +
                ", sorteAtual =" + bxSortePc1.SelectedIndex.ToString() +
                " where id = " + personagem.id ;
           
            SqlConnection con = new SqlConnection("Data Source=PEP-PC;Initial Catalog=DMC;Integrated Security=True"); 
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open(); 
            cmd.ExecuteNonQuery();

            for (int i = 0; i < 9; i++) {

                switch (i)
                {
                    case 0: sql = "UPDATE SlotsMagicos set Usado = " + comboBox1.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 1: sql = "UPDATE SlotsMagicos set Usado = " + comboBox2.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 2: sql = "UPDATE SlotsMagicos set Usado = " + comboBox3.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 3: sql = "UPDATE SlotsMagicos set Usado = " + comboBox4.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 4: sql = "UPDATE SlotsMagicos set Usado = " + comboBox5.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 5: sql = "UPDATE SlotsMagicos set Usado = " + comboBox6.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 6: sql = "UPDATE SlotsMagicos set Usado = " + comboBox7.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 7: sql = "UPDATE SlotsMagicos set Usado = " + comboBox8.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    case 8: sql = "UPDATE SlotsMagicos set Usado = " + comboBox9.SelectedIndex + " where personagemId =" + personagem.id + " and circuloId = " + (i + 1);
                        break;
                    default:
                        break;
                }

                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                
            }
            con.Close();
            MessageBox.Show("Dados salvos com sucesso!");
        }
    }
}
