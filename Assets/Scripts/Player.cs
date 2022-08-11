using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player player;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();
    [SerializeField] private int _currentWayPointNumber;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private PlayerAnimationCondition _playerAnimationCondition;
    [SerializeField] private Button _startButton;
    [SerializeField] private Gun _playerGun;

    public enum PlayerAnimationCondition
    {
        IDLE,
        RUNNING,
        AIMING
    }

    private void Awake()
    {
        if (player == null)
            player = this;
    }

    private void Start()
    {
        _startButton.onClick.AddListener(() => FirstTap());
    }

    private void FirstTap()
    {
        GoToTheNextWayPoint();
        _startButton.gameObject.SetActive(false);
    }

    public void GoToTheNextWayPoint()
    {
        _playerGun.gameObject.SetActive(false);
        SetAnimation(PlayerAnimationCondition.RUNNING);
        _navMeshAgent.SetDestination(_wayPoints[_currentWayPointNumber++].position);
    }

    public void SetAnimation(PlayerAnimationCondition playerAnimationCondition)
    {
        _playerAnimationCondition = playerAnimationCondition;
        _animator.SetInteger("Condition", (int)playerAnimationCondition);
    }

    public void TakeAim()
    {
        SetAnimation(PlayerAnimationCondition.AIMING);
        _playerGun.gameObject.SetActive(true);
    }
}
