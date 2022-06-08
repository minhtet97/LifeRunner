using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeleft = 10.0f;
    public Text counting;
    [SerializeField]
    //private Spawner sp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        counting.text = (timeleft).ToString("0");
        if(timeleft <= 0)
        {
           // sp.spawn = true;
        }
    }
}
