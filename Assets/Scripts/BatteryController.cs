using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BatteryController : MonoBehaviour
{
    [SerializeField]
    private MovementController agent;
    [SerializeField]
    private TMP_Text batteryText;
    [SerializeField]
    private float chargeSpeed = .2f;
    [SerializeField]
    private float unchargeMoveSpeed = .2f;
    [SerializeField]
    private float unchargeNightSpeed = .06f;
    [SerializeField]
    private float unchargeMoveNightSpeed = 0.08f;

    private GameManager gameManager;
    private LightingManager lightingManager;
    [SerializeField]
    private float battery = 100f;

    public bool inStorm = false;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        lightingManager = GetComponent<LightingManager>();
        UpdateBattery(battery);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = lightingManager.GetTime();
        
        // If it's day(and not in the storm) - charge battery
        if (currentTime > 5.3f && currentTime < 20f && !inStorm)
        {
            if(agent.GetAgentSpeed()<0.1f)
                battery += chargeSpeed * Time.deltaTime;
            else
                // Uncharge if Player is moving
                battery -= unchargeMoveSpeed * Time.deltaTime;
        }
        // If it's night or in the storm - slowly uncharge
        else
        {
            if (agent.GetAgentSpeed() < 0.1f)
                battery -= unchargeNightSpeed * Time.deltaTime;
            else
                // Uncharge if Player is moving
                battery -= unchargeMoveNightSpeed * Time.deltaTime;
        }
        


        


        if (battery > 100f)
            battery = 100f;
        else if (battery < 0f || Input.GetKeyDown(KeyCode.K))
        {
            battery = 0f;
            gameManager.EndGame();
            // TODO: Player Lost!
        }
        
        UpdateBattery(battery);

    }
        

    public void UpdateBattery(float battery)
    {
        this.battery = battery;
        batteryText.text = "Battery: " + battery.ToString("0.00") + "%";
    }
}
