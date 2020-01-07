using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject spikeTrap;
    public float respawnTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void spawnEnemy(){
        GameObject a = Instantiate(spikeTrap) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
