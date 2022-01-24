using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolCounter : MonoBehaviour
{
    private LightingManager lightingManager;
    [SerializeField]
    private TMP_Text solsText;

    public float prevTime = -100f;
    private uint sols = 1;

    public void SetSols(uint sols) => this.sols = sols;
    public uint GetSols() => this.sols;

    private void Awake()
    {
        lightingManager = GetComponent<LightingManager>();
        UpdateSols(sols);
    }

    void Update()
    {
        
        // New Day
        if(lightingManager.GetTime() < prevTime)
        {
            sols++;
            UpdateSols(sols);
        }

        prevTime = lightingManager.GetTime();
    }

    public void UpdateSols(uint newSols)
    {
        solsText.text = "Sol:\n" + newSols.ToString();
    }
}
