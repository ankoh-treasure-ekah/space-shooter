using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool startScreen;
    public GameObject startMenu;
    [SerializeField]
    private GameObject _playerPrefab;
    private uiManager _uimanager;
    private GameManager _gamemanager;


    void Start()
    {

       
        _uimanager = GameObject.Find("Canvas").GetComponent<uiManager>();
        //startScreen = true;
       
    }

   

    // Update is called once per frame
    void Update()
    {
       
        updateStartScreen();

    }

    public void updateStartScreen()
    {

        //here we want to update the screen when e hit the space key to spawn our player

        if (startScreen == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Instantiate(_playerPrefab, new Vector3(0, 0, -3.29f), Quaternion.identity);

                startScreen = false;
                _uimanager.hideTitleScreen();
            }

        }
       
    }
}
