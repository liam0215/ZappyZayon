using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    private Animator anim;
    private int animDir = 1;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        float dx = 0.0f, dy = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            dy = speed;
            animDir = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dy = -speed;
            animDir = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dx = speed;
            animDir = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dx = -speed;
            animDir = 3;
        }

        if (dx == 0.0f && dy == 0.0f)
        {
            anim.speed = 0;
        } else
        {
            anim.speed = 1;
        }

        if (dx != 0.0f && dy != 0.0f)
        {
            dx *= Mathf.Cos(Mathf.PI / 4);
            dy *= Mathf.Sin(Mathf.PI / 4);
        } 

        anim.SetInteger("dir", animDir);
        transform.Translate(dx * Time.deltaTime, dy * Time.deltaTime, 0);
    }
}
