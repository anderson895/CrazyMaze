using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLvl2 : MonoBehaviour
{
    public Joystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    public GameObject door;
    private int keys = 0;

    public Animator animator;
    public Text keyAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioManager.instance.Play("Background");
    }

    private void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Keys")
        {
            keys++;
            keyAmount.text = "Keys: " + keys;
            AudioManager.instance.Play("GetKey");
            Destroy(collision.gameObject);
        }
        if (keys == 2)
        {
            Destroy(door);
        }
    }
}
