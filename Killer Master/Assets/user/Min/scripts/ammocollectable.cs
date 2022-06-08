using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammocollectable : MonoBehaviour
{
    public int ammoToAdd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colGo = col.gameObject;
        if(colGo.name == "Player")
        {
            colGo.GetComponent<playerbullet>().UpdateAmmo(ammoToAdd);
            Destroy(gameObject);
        }
    }
}
