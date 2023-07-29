using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button button;

    public void Start()
    {
        // masterMixer.SetFloat("MasterVolume", 1f);
        audioSource.Play();
        UpdateTextButton();
    }
    
    public void SwitchVolume()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
        
        UpdateTextButton();
    }

    private void UpdateTextButton()
    {
        if (audioSource.isPlaying)
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Disable sounds";
        else
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Enable sounds";
    }
}