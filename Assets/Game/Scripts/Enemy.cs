using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 1.7f;
    public GameObject enemyexplotionprefab;
    private uiManager _uimanager;
    private GameManager _gameManager;
    [SerializeField]
    private AudioClip _audioClip;
    
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<uiManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



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
        if(_gameManager.startScreen == false)
        {
            if (transform.position.y < -6.64)
            {
                float randomX = Random.Range(-7.56f, 7.56f);
                transform.position = new Vector3(randomX, 6.52f, -3.29f);

            }
            else
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }

        }
        else
        {
            Destroy(this.gameObject);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       

        Player player = other.GetComponent<Player>();
        Laser laser = other.GetComponent<Laser>();
        if(other.tag == "Player")
        {
            player.Damage();
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            Instantiate(enemyexplotionprefab, transform.position, Quaternion.identity);
        }

        else if(other.tag == "Laser")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
            if (_uimanager != null)
            {
                _uimanager.updateScore();
            }
            Instantiate(enemyexplotionprefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
          
        }
    }
   
}
