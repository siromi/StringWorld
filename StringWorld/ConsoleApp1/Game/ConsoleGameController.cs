using System;

namespace ConsoleApp1
{
    // ゲームの進行を管理するクラス
    public class ConsoleGameController
    {
        private Player player;

        // ゲームの進行を開始する
        public void PlayGame()
        {
            //名前入力
            this.player = this.CreatePlayer();

            //戦闘
            Console.WriteLine("戦闘開始");

            // ファクトリ経由で敵の作成
            Enemy enemy = this.CreateEnemyOne();

            // enemy.MakeEnemy();

            while (true)
            {
                //ステータス表示
                this.player.PrintStatus();
                enemy.PrintStatus();

                // ターン開始時(行動前に)敵の行動をスケジュールしておく
                enemy.NextAction = DamegeF.Normal;

                //攻撃
                this.SetPlayerAction();
                this.player.Attack(enemy);

                //敵が死んだら
                if (enemy.IsDead)
                {
                    Console.WriteLine($"{enemy.Name}を倒した！"); // ごめん勝手に追加した
                    break;
                }

                enemy.Attack(this.player);

                if (this.player.IsDead)
                {
                    break;
                }
            }

            this.JudgeGame();
        }

        // プレイヤーを作成する
        public Player CreatePlayer()
        {
            string tempPlayerName = "";

            while (true)
            {
                Console.WriteLine("名前を入力してください(６文字以内)");
                tempPlayerName = Console.ReadLine();

                if (tempPlayerName.Length > 6)
                {
                    Console.WriteLine("名前は6文字以内で入力してください \n");
                }
                else if (tempPlayerName.Length <= 0)
                {
                    Console.WriteLine("名前が入力されていません \n");
                }
                else
                {
                    Console.WriteLine($"プレイヤー名[{tempPlayerName}]を登録しました \n"); // C#6.0の"String interpolation(文字列補間)"機能で表記
                    break;
                }
            }

            // プレイヤーの作成
            return new Player()
            {
                Name = tempPlayerName,
                MaxHp = 10,
                Hp = 10,
                Atk = 5
            };
        }

        // 1体敵を作成する
        public Enemy CreateEnemyOne()
        {
            return EnemyFactory.CreateEnemy(EnemyFactory.EnemyType.Slime); // とりあえず固定
        }

        // プレーヤの次の行動を入力する
        public void SetPlayerAction()
        {
            //攻撃
            Console.WriteLine("\n 攻撃を入力 \n　A.通常攻撃 S.魔法攻撃 D.防御 \n");
            string attackKey = Console.ReadLine();

            DamegeF nextAction = DamegeF.None;

            switch (attackKey.ToLower())
            {
                case "a": nextAction = DamegeF.Normal; break;
                case "s": nextAction = DamegeF.Magic; break;
                case "d": nextAction = DamegeF.Guard; break;
                default: break;
            }

            this.player.NextAction = nextAction;
        }

        // 終了時の処理
        public void JudgeGame()
        {
            if (!this.player.IsDead)
            {
                Console.WriteLine($"\n{this.player.Name}は勝利した！");
            }
            else
            {
                Console.WriteLine($"\n{this.player.Name}は力尽きてしまった…");
            }
        }
    }
}