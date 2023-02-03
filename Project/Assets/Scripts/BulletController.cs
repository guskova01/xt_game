using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyPrefab.tag))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
    

    
}
