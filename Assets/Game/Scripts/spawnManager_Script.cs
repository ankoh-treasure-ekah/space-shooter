using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager_Script : MonoBehaviour
    
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject[] powerups;
    private GameManager _gameManager;
    private uiManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<uiManager>();
        _gameManager.startScreen = true;
    }

    public void spawnOnPlayerStart()
    {
        StartCoroutine(EnemySpawnRoutin());
        StartCoroutine(powerUpRoutine());
    }

   IEnumerator EnemySpawnRoutin()
    {
        while (_gameManager.startScreen == false)
        {
            Instantiate(Enemy, new Vector3(Random.Range(-8.66f, 8.66f), 4.52f, -3.29f), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator powerUpRoutine()
    {
        while (_gameManager.startScreen == false)
        {
            int powerupchange = Random.Range(0, 3);
            Instantiate(powerups[powerupchange],transform.position = new Vector3(Random.Range(-8.66f, 8.66f), 6.52f, -3.29f), Quaternion.identity);
            yield return new WaitForSeconds(14.0f);
            
       }
    }
}
