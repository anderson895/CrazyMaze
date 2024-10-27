using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.AI;

public class AIChase : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;
    private int waypointIndex = 0;

    public GameObject player;
    public float speed;
    public float distanceBetween;
    Vector2 move;
    public Animator animator;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        animator.SetFloat("Walking", move.x);
        animator.SetFloat("Walking", move.y);

    }

    private void Move()
    {   
        if (distance < distanceBetween)
        {
            
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            AudioManager.instance.Play("EnemyAlert");
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }
}
