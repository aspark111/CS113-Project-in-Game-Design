using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySpriteScript : MonoBehaviour {

	public string horizontal_axis_name = "Horizontal";
	public string vertical_axis_name = "Vertical";
	public string rotate_button_name = "Jump";

    int speed = 10; //units per second as opposed to units per frame
    int speed_rotation = 180;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.deltaTime;
        float displacement_x = Input.GetAxis(horizontal_axis_name) * speed * time;
        float displacement_y = Input.GetAxis(vertical_axis_name) * speed * time;
        transform.position += new Vector3(displacement_x, displacement_y, 0);

        if (Input.GetButton(rotate_button_name))
        {
            transform.Rotate(0, 0, speed_rotation*time);
        }
	}
}
