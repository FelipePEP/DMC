using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Personagem
    {
        public int id { get; set; }
        public string classe { get; set; }
        public string raca { get; set; }

        public String nome { get; set; }
        public String jogador { get; set; }
        public int[] hp { get; set; }
        public int sorte { get; set; }
        public int sorteAtual { get; set; }
        public int inspiracao { get; set; }
        public int exaustao { get; set; }
        public int xp { get; set; }
        public int[] slots { get; set; }
        public int[] slotsUsados { get; set; }
        public Personagem()
        {
            hp = new int[2];
            slots = new int[9];
            slotsUsados = new int[9];
        }

    }
}
