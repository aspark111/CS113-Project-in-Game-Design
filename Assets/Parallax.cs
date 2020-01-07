using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform player;
    private float length, startpos;
    public GameObject camera;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos = player.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float dist = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y,
            transform.position.z);

        if(temp > startpos + length)
        {
            startpos += length;
        }
        if(temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
