using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyController : HVRDamageHandlerBase
{
    UnityEngine.AI.NavMeshAgent agent;

    public EnemySpawner enemySpawner;

    [SerializeField] private float timeBetweenAttacks = 1;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float maxHealth = 50f;

    [SerializeField] private Image _healthImage;

    private PlayerData _player;
    private int _deadDistance = 2;
    private float _timerAttack = 0;
    private Transform _cameraTransform;
    private float currentHealth;

    [Inject]
    public void Construct(PlayerData player)
    {
        _player = player;
    }

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //_cameraTransform = _player.GetComponent<HVRPlayerController>().Camera;
        currentHealth = maxHealth;
    }


    void Update()
    {
        agent.destination = _player.gameObject.transform.position;
        _healthImage.transform.LookAt(_cameraTransform);
        if (Vector3.Distance(_player.gameObject.transform.position, gameObject.transform.position) < _deadDistance)
        {
            _timerAttack -= Time.deltaTime;
            if (_timerAttack <= 0)
            {

                _player.TakeDamage(damage);
                _timerAttack = timeBetweenAttacks;
            }
        }
    }
    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _healthImage.fillAmount = currentHealth / maxHealth;
        if (currentHealth < 0)
        {
            Die();
        }
    }
    [ContextMenu("Умереть")]
    public void Die() {
        enemySpawner.curentWaweCount -= 1;
        Destroy(this.gameObject);
    }

}
