using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuBG : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject PlayButton;
    public GameObject OptionsButton;
    public TextMeshProUGUI labelText;
    Animator animator;

    private void Start()
    {
        animator = menuPanel.GetComponent<Animator>();
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MarsScene");
    }

    public void ShowMenu()
    {
        animator.SetTrigger("openMenu");
        labelText.text = "Main Menu";
        PlayButton.SetActive(true);
        OptionsButton.SetActive(true);
    }

    public void VideoOptions()
    {
        animator.SetTrigger("closeMenu");
        PlayButton.SetActive(false);
        OptionsButton.SetActive(false);
        labelText.text = "Video Options";
    }

    public void ChangeVidoSettings(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel, true);
        Debug.Log("Video settings changed to " + QualitySettings.names[QualitySettings.GetQualityLevel()]);
    }
}
