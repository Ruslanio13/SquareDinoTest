using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun gun;
    [SerializeField] private List<Bullet> _clip = new List<Bullet>();
    [SerializeField] private int _currentBulletIndex;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        if (gun == null)
            gun = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                    hit.collider.gameObject.GetComponent<Enemy>().GetDamage();
                _clip[_currentBulletIndex].Fire(hit.point);
                _currentBulletIndex++;
                if (_clip.Count == _currentBulletIndex)
                    _currentBulletIndex = 0;
            }
        }
    }
}
