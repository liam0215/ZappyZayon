using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    private Animator anim;
    private int animDir = 1;
    public Image[] hearts;
    public int maxHealth;
    private int currentHealth;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        getHealth();
	}

    void getHealth()
    {
        for(int i = 0; i < maxHealth; i++)
        {
            hearts[i].gameObject.SetActive(false);
        }
        for(int i = 0; i < maxHealth; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].gameObject.SetActive(true);
            } else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        if(Input.GetKeyDown(KeyCode.P))
        {
            currentHealth--;
        }
        if(Input.GetKeyDown(KeyCode.L) && currentHealth < maxHealth)
        {
            currentHealth++;
        }
        getHealth();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("stuff");
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
