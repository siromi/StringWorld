using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            //名前入力
            Player player = new Player();
            player.Name();

            //戦闘
            Console.WriteLine("戦闘開始");
            Enemy enemy = new Enemy();

            Console.WriteLine("敵が1体現れた \n");

            while (true)
            {
                //ステータス表示
                enemy.Print();
                player.Print();

                //攻撃
                Console.WriteLine("\n 攻撃を入力 \n　A.通常攻撃 S.魔法攻撃 D.防御 \n");
                string attackKey = Console.ReadLine();

                if (attackKey == "a" || attackKey == "A")
                {
                    player.Attack(enemy);
                }
                else if (attackKey == "s" || attackKey == "S")
                {
                    player.Magic(enemy);
                }
                else if (attackKey == "d" || attackKey == "D")
                {
                    player.Guard();
                }
                else
                {

                }

                //敵が死んだら
                if(enemy .DeadF)
                {
                    break;
                }

                enemy.Attack(player);

                if(player .DeadF)
                {
                    break;
                }
            }

            if (!player.DeadF)
            {
                player.Win();
            }
            else
            {
                enemy.Win();
            }
               


        }
    }
}
