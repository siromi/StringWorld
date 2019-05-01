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
        int attack = 5;

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

            Console.WriteLine("名前を入力してください(６文字以内)");
            name = Console.ReadLine();
            Console.WriteLine("プレイヤー名[{0}]を登録しました \n", name);
        }

        public void Print()
        {
            Console.WriteLine(name + ":" + hp);
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

            attack += 5;
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
            Console.WriteLine("{0}は{1}のダメージを受けた！\n", name, damege);
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

        public void Win()
        {
            Console.WriteLine(name + "は勝利した！");
        }
    }
}
