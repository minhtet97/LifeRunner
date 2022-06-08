using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float TimeToMove = 0.5f;
    int numofMovement = 0;
    float speed = 0.25f;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numofMovement == 14)
        {
            transform.Translate(new Vector3(0,-1,0));
            numofMovement = -1;
            speed = -speed;
            timer = 0;
        }
        timer += Time.deltaTime;
        if(timer > TimeToMove)
        {
            transform.Translate(new Vector3( -0.2f, 0 , 0));
            timer = 0;
            numofMovement++;
        }
    }
}
