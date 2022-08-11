using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private EnemyWave _enemyWave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeAim();
            if (_enemyWave != null)
                _enemyWave.GetEnemyWaveActive();
            gameObject.SetActive(false);
        }        
    }
}
