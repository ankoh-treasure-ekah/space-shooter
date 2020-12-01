using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        //if player goes off screen at the bottom 
        //player respawns back at the top
 

    }

    private void movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.52)
        {
            float randomX = Random.Range(-8.66f, 8.66f);
            transform.position = new Vector3(randomX, 6.52f, -3.29f);
            
        }
        else
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("hit with " + other.name);

        Player player = other.GetComponent<Player>();
        Laser laser = other.GetComponent<Laser>();
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            player.playerLife = player.playerLife - 1;
        }

        if(other.name == "laser")
        {
            Destroy(this.gameObject);
            
        }
    }
    
}
