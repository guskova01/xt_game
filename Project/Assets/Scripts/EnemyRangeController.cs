using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine;
using Zenject;

public class EnemyRangeController : HVRDamageHandlerBase
{
    public NavMeshAgent agent;

    public EnemySpawner enemySpawner;

    [SerializeField] private float timeBetweenAttacks = 1;
    [SerializeField] private float damage = 10;
    [SerializeField] private float maxHealth = 50f;

    [SerializeField] private Image _healthImage;

    [SerializeField] private PlayerData _player;
    [SerializeField] private int _deadDistance = 2;
    [SerializeField] private float _timerAttack = 0;
    private Transform _cameraTransform;
    private float currentHealth;



    [Inject]
    public void Construct(PlayerData player)
    {
        _player = player;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = _player.gameObject.transform.position;
        currentHealth = maxHealth;
    }


    void Update()
    {
        RaycastHit hit;
        _healthImage.transform.LookAt(_cameraTransform);
        if (!Physics.Raycast(transform.position, _player.gameObject.transform.position, out hit, Vector3.Distance(_player.gameObject.transform.position, gameObject.transform.position), 7))
        {
            agent.enabled = false;
            _timerAttack -= Time.deltaTime;
            if (_timerAttack <= 0)
            {

                _player.TakeDamage(damage);
                _timerAttack = timeBetweenAttacks;
            }
        }
        else
        {
            agent.enabled = true;
            agent.destination = _player.gameObject.transform.position;
            Debug.Log(hit.collider.gameObject.name);
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
    public void Die()
    {
        enemySpawner.curentWaweCount -= 1;
        Destroy(gameObject);
    }
}
