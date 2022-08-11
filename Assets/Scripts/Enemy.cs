using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyWave _enemyWave;
    [SerializeField] private bool _isDead;
    [SerializeField] private bool _isMortal;
    [SerializeField] private int _healthPoints;
    [SerializeField] private List<Image> _hearts = new List<Image>();
    [SerializeField] private Canvas _healthCanvas;
    [SerializeField] private Sprite _fallHeart;

    private void Start()
    {
        _healthPoints = _hearts.Count;
    }

    private void OnMouseDown()
    {
        if (!_isDead && _isMortal)
            GetDamage();
    }

    private void GetDamage()
    {
        Gun.gun.Hit(transform.position);
        _hearts[_hearts.Count - _healthPoints].sprite = _fallHeart;
        _healthPoints -= 1;
        if (_healthPoints == 0)
            Die();
    }

    private void Die()
    {
        var animationIndex = Random.Range(1, 4);
        _animator.Play("Die " + animationIndex.ToString());
        _enemyWave.SubtractEnemy();
        _isDead = true;
        _healthCanvas.gameObject.SetActive(false);
    }

    public void BecomeMortal() => _isMortal = true;
}
