using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    private GameManager GM;
    public Vector2 LastCheckpointPos;
    public GameObject playerPrefab;
    public bool isPaused;
    [Header("Paineis e Menu")]
    public GameObject pausePanel;
    public GameObject PausePrefab;
    public Canvas CanvasGO;
    public PlayerController Player;
    public Transform PlayerTransform;
    public List<EnemyAI> Enemies = new List<EnemyAI>();
    public PlayerData PD;

    void Awake()
    {
        
        //Debug.Log("GameManager Awake");

        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(instance);
        }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }

    private void Start() //find object playerdata, checar se ele existe, se não, criar.
    {

        //Debug.Log("GameManager Start");

        
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        CreatePlayerData();
        PD = PlayerData.PData;
        LastCheckpointPos = PD.Last;
        //Debug.Log(LastCheckpointPos);
        Time.timeScale = 1f;
        SearchPausePanel();
        Respawn();
        GetEnemies();
        

    }

    private void Update()
    {
        LastCheckpointPos = PD.Last;
        CheckUpdate();
    }

    public void Respawn()
    {

        //Debug.Log("Respawn");

        GameObject PlayerGO = Instantiate(playerPrefab, new Vector3 (LastCheckpointPos.x, LastCheckpointPos.y, 0), Quaternion.identity);
        Player = PlayerGO.GetComponent<PlayerController>();
        PlayerTransform = PlayerGO.GetComponent<Transform>();
        Camera.main.GetComponent<CameraController>().SetTarget(PlayerTransform);
        SearchPausePanel();


    }

    void CheckUpdate()
    {
        if (!isPaused)
        {

                
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }

    void PauseScreen()
    {
        if (isPaused)
        {
           isPaused = false;
           Time.timeScale = 1f;
           pausePanel.SetActive(false);
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
        }
        else
        {
           isPaused = true;
           Time.timeScale = 0f;
           pausePanel.SetActive(true);
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
        }
    }

    public void SearchPausePanel()
    {
        if (GM.pausePanel == null)
        {
            GameObject PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if (PauseMenu == null)
            {
                Debug.Break();
            }

            Debug.Log(PauseMenu);
            GM.pausePanel = GameObject.FindGameObjectWithTag("PauseMenu").gameObject;
        }
    }

    public void GetEnemies()
    {
        Enemies.AddRange(GameObject.FindObjectsOfType<EnemyAI>());
        foreach (var Enemy in Enemies)
        {
            Enemy.SetPlayer(Player);
        }
    }

    public void CreatePlayerData()
    {

        if(PlayerData.PData == null)
        {
            Instantiate(new GameObject("PlayerData").AddComponent<PlayerData>(), new Vector3(0f, 0f, 0f), Quaternion.identity);
        }


    }

}
