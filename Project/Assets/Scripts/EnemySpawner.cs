using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private DiContainer diContainer;
    public List<GameObject> prefabs;
    public List<GameObject> spawnPoints;
    [SerializeField] float timer = 10f;
    public  int curentWaweCount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = 10f;
            Spawn();
        }
        timer -= Time.deltaTime;
    }
    void Spawn()
    {
        foreach(GameObject point in spawnPoints)
        {
            GameObject obj = diContainer.InstantiatePrefab(prefabs[Random.Range(0, prefabs.Count )]);
            obj.transform.position = point.transform.position;
            obj.GetComponent<EnemyController>().enemySpawner = this;
        }
    }
}
