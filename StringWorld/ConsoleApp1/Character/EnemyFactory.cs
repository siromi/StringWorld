using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    /// <summary>
    /// 敵を作成するためのファクトリクラス
    /// </summary>
    public static class EnemyFactory
    {
        public enum EnemyType
        {
            Slime = 0,
        }

        // 敵の生成ルールを記録したテーブル
        private static Dictionary<EnemyType, Func<Enemy>> enemyCreateTable = new Dictionary<EnemyType, Func<Enemy>>()
        {
            { EnemyType.Slime, ()=>new Enemy(){ Name = "スライム", MaxHp = 10, Hp = 10, Atk = 3 } },
        };

        // 敵の生成
        public static Enemy CreateEnemy(EnemyType type)
        {
            return enemyCreateTable[type](); // 存在チェックはとりあえずしない
        }
    }
}