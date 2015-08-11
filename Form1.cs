using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Personagem[] ListaPC = new Personagem[5];

        public Form1()
        {
            InitializeComponent();
            this.carregarListaPC();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            lblPc1.Text = this.ListaPC[0].Jogador;
            pc1hp.Text = this.ListaPC[0].Hp[0].ToString();

            bxSortePc1.SelectedText = this.ListaPC[0].Sorte.ToString();
            bxInspiraPc1.SelectedText = this.ListaPC[0].Inspiracao.ToString();
            bxExaustaoPc1.SelectedText = this.ListaPC[0].Exaustao.ToString();

            lblSlotMax1Pc1.Text = this.ListaPC[0].Slots[0].ToString();
            lblSlotMax2Pc1.Text = this.ListaPC[0].Slots[1].ToString();
            lblSlotMax3Pc1.Text = this.ListaPC[0].Slots[2].ToString();
            lblSlotMax4Pc1.Text = this.ListaPC[0].Slots[3].ToString();
            lblSlotMax5Pc1.Text = this.ListaPC[0].Slots[4].ToString();
            lblSlotMax6Pc1.Text = this.ListaPC[0].Slots[5].ToString();
            lblSlotMax7Pc1.Text = this.ListaPC[0].Slots[6].ToString();
            lblSlotMax8Pc1.Text = this.ListaPC[0].Slots[7].ToString();
            lblSlotMax9Pc1.Text = this.ListaPC[0].Slots[8].ToString();

            bxXP1.SelectedText = this.ListaPC[0].Xp.ToString();

            comboBox1.SelectedText = this.ListaPC[0].SlotsUsados[0].ToString();
            comboBox2.SelectedText = this.ListaPC[0].SlotsUsados[1].ToString();
            comboBox3.SelectedText = this.ListaPC[0].SlotsUsados[2].ToString();
            comboBox4.SelectedText = this.ListaPC[0].SlotsUsados[3].ToString();
            comboBox5.SelectedText = this.ListaPC[0].SlotsUsados[4].ToString();
            comboBox6.SelectedText = this.ListaPC[0].SlotsUsados[5].ToString();
            comboBox7.SelectedText = this.ListaPC[0].SlotsUsados[6].ToString();
            comboBox8.SelectedText = this.ListaPC[0].SlotsUsados[7].ToString();
            comboBox9.SelectedText = this.ListaPC[0].SlotsUsados[8].ToString();


        }
        private Personagem[] carregarListaPC()
        {
            Personagem eliseu = new Personagem();
            eliseu.nome = "Aslyn";
            eliseu.Jogador = "ELISEU";
            eliseu.Hp[0] = 50;
            eliseu.Hp[1] = 50;
            eliseu.Inspiracao = 1;
            eliseu.Sorte = 3;
            eliseu.Exaustao = 0;

            eliseu.Slots[0] = 3;
            eliseu.Slots[1] = 3;
            eliseu.Slots[2] = 2;
            eliseu.Slots[3] = 1;

            eliseu.SlotsUsados[0] = 0;
            eliseu.SlotsUsados[1] = 0;
            eliseu.SlotsUsados[2] = 0;
            eliseu.SlotsUsados[3] = 0;

            this.ListaPC[0] = eliseu;
            return ListaPC;
        }

          

        #region FUNCOES


        public static int atualizaSlotMagia(Personagem pc, int circulo, int pretendido)
        {
            if (pc.Slots[circulo-1] < pretendido)
            {
                MessageBox.Show("Slots esgotados!");
                return pc.Slots[circulo-1];
            }
            else
            {
                pc.SlotsUsados[circulo-1] = pretendido;
                return pretendido;
            }
        }

        public static int atualizarHP(Personagem pc, int num, bool temp)
        {
            pc.Hp[1] += num;

            if (pc.Hp[1] > pc.Hp[0] && temp == false)
            {
                pc.Hp[1] = pc.Hp[0];
                return pc.Hp[0];
            }
            return pc.Hp[1];
        }

        public void descansoLongo(Personagem pc) {

            pc1hp.Text = (pc.Hp[0]).ToString();
            pc.Hp[1] = pc.Hp[0];
            pc1hpalterar.Text = "";
            bxExaustaoPc1.SelectedIndex = (bxExaustaoPc1.SelectedIndex - 1);
            pc.Exaustao--;
            for (var i = 0; i < 9; i++) { pc.SlotsUsados[i] = 0; }
            
            
            comboBox1.Text = "0";
            comboBox2.Text = "0";
            comboBox3.Text = "0";
            comboBox4.Text = "0";
            comboBox5.Text = "0";
            comboBox6.Text = "0";
            comboBox7.Text = "0";
            comboBox8.Text = "0";
            comboBox9.Text = "0";

            MessageBox.Show("Descanso longo realizado");
        }


        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(pc1hpalterar.Text);
            bool temp = false;
            if (checkBox1.Checked == true) { temp = true; }
            pc1hp.Text = (Funcao.atualizarHP(this.ListaPC[0], y, temp)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(pc1hpalterar.Text);
            bool temp = false;
            pc1hp.Text = (Funcao.atualizarHP(this.ListaPC[0], y * (-1), temp)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            descansoLongo(this.ListaPC[0]);
        }
        
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox1.Text);
            comboBox1.Text = (atualizaSlotMagia(this.ListaPC[0], 1, pretendido)).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox2.Text);
            comboBox2.Text = (atualizaSlotMagia(this.ListaPC[0], 2, pretendido)).ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox3.Text);
            comboBox3.Text = (atualizaSlotMagia(this.ListaPC[0], 3, pretendido)).ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox4.Text);
            comboBox4.Text = (atualizaSlotMagia(this.ListaPC[0], 4, pretendido)).ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox5.Text);
            comboBox5.Text = (atualizaSlotMagia(this.ListaPC[0], 5, pretendido)).ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox6.Text);
            comboBox6.Text = (atualizaSlotMagia(this.ListaPC[0], 6, pretendido)).ToString();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox7.Text);
            comboBox7.Text = (atualizaSlotMagia(this.ListaPC[0], 7, pretendido)).ToString();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox8.Text);
            comboBox8.Text = (atualizaSlotMagia(this.ListaPC[0], 8, pretendido)).ToString();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pretendido = Convert.ToInt32(comboBox9.Text);
            comboBox9.Text = (atualizaSlotMagia(this.ListaPC[0], 9, pretendido)).ToString();
        }
    }
}
