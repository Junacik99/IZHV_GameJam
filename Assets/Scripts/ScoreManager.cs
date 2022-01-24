using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text SamplesText;
    private uint samplesCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetSamplesText(samplesCollected);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            IncrementSamples();
    }

    public void IncrementSamples()
    {
        samplesCollected++;
        SetSamplesText(samplesCollected);
    }
    public void SetSamplesText(uint samples)
    {
        SamplesText.text = "Samples: " + samples.ToString();
    }
    public uint GetSamples() => samplesCollected;
}
