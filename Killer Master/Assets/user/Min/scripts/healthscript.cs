using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthscript : MonoBehaviour
{
    public float startHealth, chanceToSpawnAmmo;
    private float hp;

    public GameObject diePEffect, ammoDrop;
    // Start is called before the first frame update
    void Start()
    {
        hp = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;

        if(hp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if(diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }

        float spawnRate = Random.Range(0, 100f);
        if(spawnRate <= chanceToSpawnAmmo)
        {
            Instantiate(ammoDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
