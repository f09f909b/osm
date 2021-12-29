using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void FixedUpdate()
    {
        Fire();
    }

    private void Fire()
    {
        transform.Translate((Vector2.left * _speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.RestartLevel();
        }
        else if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
