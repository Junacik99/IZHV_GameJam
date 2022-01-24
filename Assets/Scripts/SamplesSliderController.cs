using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamplesSliderController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent player;
    private float playerSpeed;
    private Slider slider;
    private ScoreManager scoreManager;
    [SerializeField]
    private GoalSpawner goalSpawner;
    
    public float scanSpeed = 1.0f;

    private void OnValidate()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnEnable()
    {
        slider.value = 0f;
        playerSpeed = player.speed;
        player.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
         
        if(slider.value + scanSpeed * Time.deltaTime >= slider.maxValue)
        {
            scoreManager.IncrementSamples();
            player.speed = playerSpeed;

            goalSpawner.SelectRandomGoal();

            slider.value = 0f;
            this.gameObject.SetActive(false);
        }
        slider.value += scanSpeed * Time.deltaTime;
    }
}
