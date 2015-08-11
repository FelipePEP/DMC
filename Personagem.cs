using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Personagem
    {
        public String nome { get; set; }
        public String Jogador { get; set; }
        public int[] Hp { get; set; }
        public int Sorte { get; set; }
        public int Inspiracao { get; set; }
        public int Exaustao { get; set; }
        public int Xp { get; set; }
        public int[] Slots { get; set; }
        public int[] SlotsUsados { get; set; }
        public Personagem()
        {
            Hp = new int[2];
            Slots = new int[9];
            SlotsUsados = new int[9];
        }

    }
}
