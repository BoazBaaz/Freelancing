using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
    }

    private void Update()
    {
        MusicManager.instance.ChangeVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
    }
}
