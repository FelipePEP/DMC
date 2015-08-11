using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace WindowsFormsApplication1
{
    public static class Funcao
    {

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

        //public static bool atualizaSlotMagia(Personagem pc, int circulo, int pretendido)
        //{
        //    if (pc.Slots[circulo] < pretendido)
        //    {
        //        return false;
        //    }

        //    pc.SlotsUsados[circulo] = pretendido;
        //    return true;

        //}


    }
}
