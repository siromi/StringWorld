using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        string name;
        int hp;
        int maxHp = 10;
        int attack = 1;

        public bool DeadF;

        enum DamegeF
        {
            Normal,
            Magic,
            Guard,
        }
        DamegeF damageF = DamegeF.Normal ;

        public Player()
        {
            hp = maxHp;
        }

        public void Name()
        {
            while (true)
            {
                Console.WriteLine("名前を入力してください(６文字以内)");
                name = Console.ReadLine();

                if (name.Length > 6)
                {
                    Console.WriteLine("名前は6文字以内で入力してください \n");
                }
                else if(name.Length <= 0)
                {
                    Console.WriteLine("名前が入力されていません \n");
                }
                else
                {
                    Console.WriteLine("プレイヤー名[{0}]を登録しました \n", name);
                    break;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("\n"+name + ":" + hp);
        }


        public void Attack(Enemy enemy)
        {
            Console.WriteLine( name + "の攻撃");
            enemy.Damage(attack);
        }
        public void Magic(Enemy enemy)
        {
            Console.WriteLine(name + "の魔法攻撃");
            damageF = DamegeF.Magic;

            attack += 8;
            enemy.Damage(attack);
        }
        public void Guard()
        {
            Console.WriteLine(name + "は防御した");
           damageF =  DamegeF.Guard;
        }

        public void Damage(int damege)
        {
           switch (damageF)
            {
                case DamegeF.Normal:
                    break;
                case DamegeF.Magic:
                    damege += 4;
                    break;
                case DamegeF.Guard:
                    damege = 0;
                    break;


            }
            hp -= damege;
            Console.WriteLine("{0}は{1}のダメージを受けた！", name, damege);
            if (hp <= 0)
            {
                DeadF = true;
            }
           

        }

        public void LevelUp()
        {
            maxHp += 10;
            hp = maxHp;
        }

        public void Judge()
        {
            if (!DeadF)
            {
                Console.WriteLine("\n" + name + "は勝利した！");
            }
            else
            {
                Console.WriteLine("\n" + name + "は力尽きてしまった…");
            }
        }

      
    }
}
