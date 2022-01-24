using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    [SerializeField]
    private GameObject backButton;

    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject videoOptsButton;
    [SerializeField]
    private GameObject soundButton;
    [SerializeField]
    private GameObject controlsButton;
    [SerializeField]
    private GameObject mainMenuButton;

    [SerializeField]
    private GameObject[] videoOpts;

    [SerializeField]
    private GameObject[] soundOpts;

    [SerializeField]
    private GameObject controlsText;

    public void ChangeVidoSettings(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel, true);
        Debug.Log("Video settings changed to " + QualitySettings.names[QualitySettings.GetQualityLevel()]);
    }

    public void ShowVideoOptions()
    {
        playButton.SetActive(false);
        videoOptsButton.SetActive(false);
        soundButton.SetActive(false);
        controlsButton.SetActive(false);
        mainMenuButton.SetActive(false);

        backButton.SetActive(true);
        foreach(var opt in videoOpts)
            opt.SetActive(true);

        label.text = "Video Options";
    }
    public void ShowSoundSettings()
    {
        playButton.SetActive(false);
        videoOptsButton.SetActive(false);
        soundButton.SetActive(false);
        controlsButton.SetActive(false);
        mainMenuButton.SetActive(false);

        backButton.SetActive(true);

        foreach (var opt in soundOpts)
            opt.SetActive(true);

        label.text = "Sound";
    }
    public void ShowControls()
    {
        playButton.SetActive(false);
        videoOptsButton.SetActive(false);
        soundButton.SetActive(false);
        controlsButton.SetActive(false);
        mainMenuButton.SetActive(false);

        backButton.SetActive(true);

        controlsText.SetActive(true);

        label.text = "Controls";
    }
    public void ShowPauseMenu()
    {
        playButton.SetActive(true);
        videoOptsButton.SetActive(true);
        soundButton.SetActive(true);
        controlsButton.SetActive(true);
        mainMenuButton.SetActive(true);

        backButton.SetActive(false);

        foreach (var opt in videoOpts)
            opt.SetActive(false);
        foreach (var opt in soundOpts)
            opt.SetActive(false);
        controlsText.SetActive(false);

        label.text = "Pause";
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
