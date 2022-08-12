using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _bulletPool;
    [SerializeField] private Vector3 _direction;

    void Update()
    {
        transform.position += _direction * Time.deltaTime * _moveSpeed;
    }

    public void Fire(Vector3 destination)
    {
        transform.localPosition = Vector3.zero;
        _direction = destination - transform.position;
        Invoke("ReturnBullet", 2f);
    }

    private void ReturnBullet()
    {
        transform.position = _bulletPool.position;
        _direction = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReturnBullet();
    }
}
