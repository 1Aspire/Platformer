using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //variables for the game
    Health damage;
    public GameObject player;

    // Vector2 direction;
    public float speed;
    public bool left = true;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        damage = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //side to side movement for the ground(spike) enemy
        if (gameObject.tag == "Spike" && left)  //is this is the spike enemy and it is set to go to the left
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y); //move left
        }

        else if (gameObject.tag == "Spike" && !left) //is this is the spike enemy and it is set to go to the right
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y); //move right
        }

        //following movement for the flying enemy
        if (gameObject.tag == "Fly")    //if this is the fly enemy
        {
            distance = Vector2.Distance(transform.position, player.transform.position); //determine the distance between it and the player

            Vector2 direction = player.transform.position - transform.position; //determine direction based on the location of both the player and the enemy


            if(distance <= 4)           //if players is within the range on of the enemy
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); //move enemy towards player
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            damage.TakeDamage(1);
        }
        
        if (coll.tag == "Wall" && left == true)
        {
            left = false;
        }

        else if (coll.tag == "Wall" && left == false)
        {
            left = true;
        }
    }
}
