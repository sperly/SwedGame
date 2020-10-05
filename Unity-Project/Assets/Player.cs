using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 0.75f;
    public Rigidbody2D rb;
    public Animator animator;
    //public HealthBar healthBar;

    public int maxHealth = 20;
    public int currentHealth;

    Vector2 movement;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        animator.SetInteger("Health", currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        if (currentHealth > 4)
        {
            moveSpeed = 0.75f;

        }
        else if (currentHealth > 0)
        {
            moveSpeed = 0.25f;
        }
        else
        {
            moveSpeed = 0.0f;
        }

        animator.SetInteger("Health", currentHealth);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            Debug.Log("Aouch");
            currentHealth -= damage;
            //healthBar.SetHealth(currentHealth);
        }
        else
        {
            Debug.Log("DEAD!");
        }
    }
}