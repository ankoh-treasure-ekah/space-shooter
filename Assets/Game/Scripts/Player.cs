using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _Speed = 7.0f;
    private float horizontalInput;
    private float verticalInput;
    private float zposition = -3.29f;
    public GameObject laserPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;
    public bool canTripleShot = false;
    [SerializeField]
    private GameObject _tripleShotprefab;
    [SerializeField]
    public bool canIncreaseSpeed = false;
    public float increasedSpeed = 1.5f;
    public int playerLife = 3; 
    [SerializeField]
    private GameObject _playerexplotionprefab;
   
    [SerializeField]
    private bool canShieldUp = false;
    [SerializeField]
    private GameObject _shields;
    public uiManager _uiManager;
    private GameManager _gameManager;
    private spawnManager_Script _spawnManager;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject[] _engine_failure;
    private int _hitcount = 0;
    

    
   
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<uiManager>();
          _audioSource = GetComponent<AudioSource>();
        

        if(_uiManager != null)
        {
            _uiManager.updateLives(playerLife);

        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("spawnManager").GetComponent<spawnManager_Script>();

        if (_spawnManager != null)
        {
            _spawnManager.spawnOnPlayerStart();
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        Movement();

        //if space key is pressed
        //spawn laser
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        { 
                Shoot();   
        }



        
    }

   
    private void Shoot()
    {
        if (Time.time > _canFire)
           
        {
            _audioSource.Play();
            if (canTripleShot == false)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1.2f, zposition), Quaternion.identity);
               


            }

            else
            {
                Instantiate(_tripleShotprefab, transform.position, Quaternion.identity);
                
            }
            _canFire = Time.time + _fireRate;
           
        }
    }

    private void Movement()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (canIncreaseSpeed == true)
        {
            transform.Translate(Vector3.up * (_Speed * increasedSpeed) * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * (_Speed * increasedSpeed) * horizontalInput * Time.deltaTime);
        }
        else
        {        
            transform.Translate(Vector3.right * Time.deltaTime * _Speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _Speed * verticalInput);
        }
        


        //if player position on the y becomes greater than 0 reset player position on the y back to 0

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, zposition);
        }
        else if (transform.position.y < -3.716)
        {
            transform.position = new Vector3(transform.position.x, -3.716f, zposition);
        }

        //if plqyer position on the x axis is greater than 11.3709 then player stops moving on the right of x
        //and also player stops moving on the left of x if position becomes less than -11.3709


        if (transform.position.x > 9.4)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, zposition);
        }
        else if (transform.position.x < -9.4)
        {
            transform.position = new Vector3(9.4f, transform.position.y, zposition);
        }
    }

    //triple shot
    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutin());
    }
    public IEnumerator TripleShotPowerDownRoutin()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    //increasing our speed for the player
    public void canIncreseSpeedOn()
    {
        canIncreaseSpeed = true;
        StartCoroutine(increasingSpeedRoutin());
    }
    public IEnumerator increasingSpeedRoutin()
    {
        yield return new WaitForSeconds(5.0f);
        canIncreaseSpeed = false;
    }

    public void Damage()
    {
       

        if (canShieldUp == true)
        {
            canShieldUp = false;
            _shields.SetActive(false);
            return;
        }
        else
        {
            _hitcount++;
            if (_hitcount == 1)
            {
                _engine_failure[0].SetActive(true);
            }
            else if (_hitcount == 2)
            {
                _engine_failure[1].SetActive(true);
            }
            playerLife--;
            _uiManager.updateLives(playerLife);

            if (playerLife < 1)
            {
                Destroy(this.gameObject);
                _uiManager.showTitleScreen();
                _gameManager.startScreen = true;
                Instantiate(_playerexplotionprefab, transform.position, Quaternion.identity);
            }
        }
    }
    
    public void shieldOn()
    {
        canShieldUp = true;
        _shields.SetActive(true);
    }
        
   
}
