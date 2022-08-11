using UnityEngine;
using System.Collections.Generic;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private int _enemyAmount;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        _enemyAmount = _enemies.Count;
    }

    public void SubtractEnemy()
    {
        _enemyAmount--;
        if (_enemyAmount == 0)
            Player.player.GoToTheNextWayPoint();
    }

    public void GetEnemyWaveActive()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].BecomeMortal();
        }
    }
}
