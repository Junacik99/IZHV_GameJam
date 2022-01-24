using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject lostPanel;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private UnityEngine.UI.Slider masterVolumeSlider;
    
    [SerializeField]
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent agent;
    private MovementController movementController;

    [SerializeField]
    private CameraController cameraController;

    private SolCounter solCounter;
    private ScoreManager scoreManager;
    private BatteryController batteryController;

    private bool gameEnded = false;
    private bool gamePaused = false;

    private float playerSpeed = 0f;

    private void Awake()
    {
        solCounter = GetComponent<SolCounter>();
        scoreManager = GetComponent<ScoreManager>();
        batteryController = GetComponent<BatteryController>();

        agent = player.GetComponent<UnityEngine.AI.NavMeshAgent>();
        movementController = player.GetComponent<MovementController>();

        lostPanel.SetActive(false);
        pausePanel.SetActive(false);
        gameEnded = false;
    }

    private void Update()
    {
        // Restart game
        if(gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MarsScene");
        }

        // Pause game
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gamePaused)
                PauseGame();
            else
                UnpauseGame();
            
        }
    }

    public void PauseGame()
    {
        gamePaused = true;
        pausePanel.SetActive(true);
        movementController.isPaused = true;
        GetComponent<PauseManager>().ShowPauseMenu();

        // Stop moving
        playerSpeed = agent.speed;
        agent.speed = 0f;

        // Stop battery
        batteryController.enabled = false;

        // Freeze camera (Maybe better off without this one)
        cameraController.enabled = false;
    }
    public void UnpauseGame()
    {
        gamePaused = false;
        pausePanel.SetActive(false);
        movementController.isPaused = false;

        agent.speed = playerSpeed;
        batteryController.enabled = true;
        cameraController.enabled = true;
    }

    public void EndGame()
    {
        // Stop moving
        agent.speed = 0f;

        // Stop battery
        batteryController.enabled = false;

        // Freeze camera (Maybe better off without this one)
        cameraController.enabled = false;

        // Show score
        lostPanel.SetActive(true);
        uint score = solCounter.GetSols() * 30 + scoreManager.GetSamples() * 100;
        scoreText.text = "Total Score: " + score.ToString();

        // Restart
        gameEnded = true;
    }

    public void AdjustVolume()
    {
        AudioListener.volume = masterVolumeSlider.value;
    }
}
