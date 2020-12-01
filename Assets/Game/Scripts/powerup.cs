using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 1.0f;
    [SerializeField]
    private int powerUpId = 0;
    [SerializeField]
    private AudioClip _audioSource;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _Speed);
        if(transform.position.y < -6.52)
        {
            Destroy(this.gameObject);
        }
        
    }
   
    //on ontrigger
    //display object collided with
      private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.tag == "Player")
        {
            //grap hold of player object
            Player player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_audioSource, Camera.main.transform.position);
            if (player != null)
            {
                //enable trippleshot
                if (powerUpId == 0)
                {
                    player.TripleShotPowerUpOn();
                }
                else if(powerUpId == 1)
                {
                    player.canIncreseSpeedOn();
                }
                else if(powerUpId == 2)
                {
                    player.shieldOn();
                }
                  //destroy game object after cantrippleshot activated
                Destroy(this.gameObject);
              
            }
        }
    }
    
    //get hold of our pleyer component 
    //grap and manipulate the player components



}
