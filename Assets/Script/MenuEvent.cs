using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvent : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;

    public void Start() {
        Time.timeScale = 1;
        AudioManager.instance.Stop("Background");
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
        
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
