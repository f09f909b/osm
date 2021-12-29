using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private void Start()
    {
        InvokeRepeating("SpawnBullet", 2.0f, 1.5f);
    }

    private void SpawnBullet()
    {
        Instantiate(bullet);
    }
}
