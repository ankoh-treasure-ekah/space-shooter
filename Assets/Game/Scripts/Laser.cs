using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 30.0f;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            //if space is pressed 
            //laser moves upward
            transform.Translate(Vector3.up * Time.deltaTime * speed);


            //if laser position y goes above 5.99
            //destroy laser

            if (transform.position.y > 5.99)
            {
                Destroy(this.gameObject);
            }
       

    }

    
}
