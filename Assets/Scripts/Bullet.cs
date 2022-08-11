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

    void OnCollisionEnter(Collision hit)
    {
        _direction = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }

    public void Fire(Vector3 destination)
    {
        transform.localPosition = Vector3.zero;
        _direction = destination - transform.position;
    }
}
