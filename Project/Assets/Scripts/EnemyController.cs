using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private float timeBetweenAttacks = 1;
    [SerializeField] private float damage = 10;

    private PlayerData _player;
    private int _deadDistance = 2;
    private float _timerAttack = 0;


    [Inject]
    public void Construct(PlayerData player)
    {
        _player = player;
    }

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = _player.gameObject.transform.position;
    }

    
    void Update()
    {
        if (Vector3.Distance(_player.gameObject.transform.position, gameObject.transform.position) < _deadDistance)
        {
            _timerAttack -= Time.deltaTime;
            if (_timerAttack <= 0 ){
                
                _player.TakeDamage(damage);
                _timerAttack = timeBetweenAttacks;
            }
        }
    }
}
