using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationenemy : MonoBehaviour
{
    public float speed;
    public Transform pos1;
    public Transform pos2;
    bool turnback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x >= pos1.position.x)
        {
            turnback = true;
            //transform.Rotate(180,0,0);
        }   
        if(transform.position.x <= pos2.position.x)
        {
            turnback = false;
            //transform.Rotate(0,0,0);
        }
        if(turnback)
        {
            transform.position = Vector2.MoveTowards(transform.position,pos2.position, speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,pos1.position, speed * Time.deltaTime);
            
        }
    }

    
}