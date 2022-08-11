using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun gun;
    [SerializeField] private List<Bullet> _clip = new List<Bullet>();
    [SerializeField] private int _currentBulletIndex;

    private void Awake()
    {
        if (gun == null)
            gun = this;
    }

    public void Hit(Vector3 destination)
    {
        _clip[_currentBulletIndex].Fire(destination);
        _currentBulletIndex++;
        if (_clip.Count == _currentBulletIndex)
            _currentBulletIndex = 0;
    }
}
