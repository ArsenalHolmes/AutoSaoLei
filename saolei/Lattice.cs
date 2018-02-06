using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saolei
{
    /// <summary>
    /// 格子
    /// </summary>
    class Lattice
    {
        public int x;
        public int y;
        public bool isLei;
        public bool isCanOpen;
        public int AroundNum;//周围雷数量

        public LatticeType lt = LatticeType.None;

        public Lattice(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string GetInfo()
        {
            switch (lt)
            {
                case LatticeType.None:
                    return "-";
                case LatticeType.Flag:
                    return "*";
                case LatticeType.Lei:
                    return "!";
                case LatticeType.Other:
                    return "o";
                case LatticeType.Number:
                    return AroundNum.ToString();
                default:
                    return "";
            }
        }

        public void Open()
        {
            if (lt==LatticeType.Flag||lt==LatticeType.Other)
            {
                return;
            }
            if (isLei)
            {
                //GG
                Console.WriteLine("游戏结束");
                return;
            }
            if (isCanOpen)
            {
                Console.WriteLine("open");
                GameManger.instances.OpenArouond(this);
            }
            lt = LatticeType.Number;
        }
    }
}
