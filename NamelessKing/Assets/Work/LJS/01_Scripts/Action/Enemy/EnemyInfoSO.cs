using System;
using UnityEngine;

[Serializable]
public struct EnemyInfo{
    public int power;
    public int hp;
    public int speed;
    public float currentCoolTime;
    public float attackCoolTime;
}

[CreateAssetMenu(menuName = "SO/Enemy/EnemyInfo")]
public class EnemyInfoSO : ScriptableObject
{
    public EnemyInfo _enemyInfo;
}
