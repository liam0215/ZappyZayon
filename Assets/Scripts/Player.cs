using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        float dx = 0.0f, dy = 0.0f;
        if (Input.GetKey(KeyCode.W)) dy = speed;
        if (Input.GetKey(KeyCode.S)) dy = -speed;
        if (Input.GetKey(KeyCode.D)) dx = speed;
        if (Input.GetKey(KeyCode.A)) dx = -speed;

        if(dx != 0.0f && dy != 0.0f)
        {
            dx *= Mathf.Cos(Mathf.PI / 4);
            dy *= Mathf.Sin(Mathf.PI / 4);
        }
        Debug.Log(dx + " " + dy + " " + speed);
        transform.Translate(dx * Time.deltaTime, dy * Time.deltaTime, 0);
    }
}
