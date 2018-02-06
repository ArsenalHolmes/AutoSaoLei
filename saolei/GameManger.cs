using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace saolei
{
    
    public enum LatticeType
    {
        None,//没开的
        Flag,//旗子
        Lei,//雷
        Other,//墙
        Number,
    }

    class GameManger
    {
        public static GameManger instances;

        public GameManger()
        {
            instances = this;
            InitGame();
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("-----------------------");
                PrintArrInfo();
                Next();
            }
        }

        Lattice[,] arr;

        public void Next()
        {
            int tempx = int.Parse(Console.ReadLine());
            int tempy = int.Parse(Console.ReadLine());
            arr[tempx, tempy].Open();
        }

        void InitGame()
        {
            int wid = int.Parse(Console.ReadLine());
            int hig = int.Parse(Console.ReadLine());
            arr = new Lattice[wid, hig];
            for (int i = 0; i < wid; i++)
            {
                for (int j = 0; j < hig; j++)
                {
                    arr[i, j] = new Lattice(i, j);
                    Lattice temp = arr[i, j];
                    if (i==0||j==0||i==wid-1||j==hig-1)
                    {
                        temp.lt = LatticeType.Other;
                    }
                    Random r = new Random();
                    if (r.Next(0,100)>70)
                    {
                        temp.isLei = true;
                    }
                }
            }
        }

        void InitLattice()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Lattice temp = arr[i, j];
                    int count = getAroundLeiNum(temp);
                    temp.AroundNum = count;
                    if (count == 0) { temp.isCanOpen = true; }
                }
            }
        }

        int getAroundLeiNum(Lattice lt)
        {
            int count = 0;
            for (int i = -1; i <= 1; i+=2)
            {
                for (int j = -1; j <= 1; j+=2)
                {
                    Lattice l = arr[lt.x + i, lt.y + j];
                    if (l.isLei) count++;
                }
            }
            return count;
        }

        public void OpenArouond(Lattice lt)
        {
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    Lattice l = arr[lt.x + i, lt.y + j];
                    l.Open();
                }
            }
        }

        void PrintArrInfo()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j].GetInfo()+" ");
                }
                Console.Write('\n');
            }
        }
    }
}
