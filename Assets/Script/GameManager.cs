using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    private GameManager GM;
    public Vector2 LastCheckpointPos;
    public GameObject playerPrefab;
    public bool isPaused;
    [Header("Paineis e Menu")]
    public GameObject pausePanel;
    public GameObject PausePrefab;
    public Canvas CanvasGO;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        LastCheckpointPos = GM.LastCheckpointPos;
        LastCheckpointPos = new Vector2 (-6f, -4f);
        Time.timeScale = 1f;

    }

    private void Update()
    {
        CheckUpdate();
        SearchPausePanel();
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, new Vector3 (LastCheckpointPos.x, LastCheckpointPos.y, 0), Quaternion.identity);
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
            GM.pausePanel = GameObject.FindGameObjectWithTag("PauseMenu").gameObject;
        }
    }

}
