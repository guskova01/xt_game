using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealthBonus : MonoBehaviour
{
    [SerializeField] private PlayerData _player;
    public float distance;
    [Inject]
    public void Construct(PlayerData player)
    {
        _player = player;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_player.gameObject.transform.position, gameObject.transform.position) < 3f)
        {
            
            _player.AddHealth();
            Destroy(this.gameObject);
        }
        distance = Vector3.Distance(_player.gameObject.transform.position, gameObject.transform.position);
        this.gameObject.transform.Rotate(0, 120 * Time.deltaTime, 0);
    }
}
