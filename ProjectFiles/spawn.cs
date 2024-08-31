using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject pipe;
    
    public float timer = 0;
    public float heightOffset = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
       float spawnRate = Random.Range(1,100);
        if(timer < spawnRate)
        {
            
            timer = timer + Time.deltaTime;
        }
        else
        {
        SpawnPipe();
        timer = 0;
        }
    }
    void SpawnPipe()
    {
        float lowestPoint= transform.position.y-heightOffset;
        float highestPoint= transform.position.y+heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
}
