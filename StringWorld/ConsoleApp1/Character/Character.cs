using System;

namespace ConsoleApp1
{
    // HPや攻撃能力を持つキャラクターの共通基底クラス
    public abstract class Character
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; } // 名前がAttackメソッドとかぶっていたので少し変更

        // 死んだかどうかを管理するフラグ
        // true : 死んだ / false : 生きている
        public bool IsDead { get; private set; }

        // 次の行動を記録する変数
        public DamegeF NextAction { get; set; }

        // 対象へ攻撃する
        public virtual void Attack(Character target)
        {
            int damege = 0;

            switch (this.NextAction)
            {
                case DamegeF.Normal:
                    Console.WriteLine($"{this.Name}の攻撃");
                    damege = this.Atk;
                    break;
                case DamegeF.Magic:
                    Console.WriteLine($"{this.Name}の魔法攻撃");
                    damege = this.Atk + 8;
                    break;
                case DamegeF.Guard:
                    Console.WriteLine($"{this.Name}は防御した");
                    damege = 0;
                    break;
                case DamegeF.None:
                    Console.WriteLine($"{this.Name}は様子を見ている"); // ごめん勝手に追加した
                    damege = int.MinValue;
                    break;
            }

            if (damege != int.MinValue)
            {
                target.TakeDamage(damege);
            }
        }

        // 対象からのダメージ反映
        public virtual void TakeDamage(int damege)
        {
            this.Hp -= damege;
            Console.WriteLine($"{this.Name}に{damege}のダメージをあたえた！");
            if (this.Hp <= 0)
            {
                this.IsDead = true;
            }
        }

        // 自分のステータスを表示
        public virtual void PrintStatus()
        {
            Console.WriteLine($"\n{this.Name}:HP={this.Hp}");
        }

        // レベルアップ
        public virtual void LevelUp()
        {
            this.MaxHp += 10;
            this.Hp = this.MaxHp;
        }
    }
}
