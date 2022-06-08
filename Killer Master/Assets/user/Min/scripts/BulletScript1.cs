using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript1 : MonoBehaviour
{
    public GameObject diePEffect;
    public float dieTime, damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name != "Player")
        {
            if(collisionGameObject.GetComponent<healthscript>() != null)
            {
                collisionGameObject.GetComponent<healthscript>().TakeDamage(damage);
            }
            Die();
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    void Die()
    {
        if(diePEffect != null)
        {
            Instantiate(diePEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
