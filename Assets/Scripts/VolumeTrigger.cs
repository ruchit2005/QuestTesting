using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeTrigger : MonoBehaviour
{
    public Button muteButton;
    public Image muteButtonImage; // Assign this manually in the Inspector
    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public Slider volumeSlider;

    public AudioSource source;
    private bool isMuted = false;

    void Start()
    {
        source.volume = 0.25f; // Set initial volume to max
        source.Play();
        volumeSlider.value = source.volume;
        volumeSlider.maxValue = 1.0f; // Ensure max volume is 1
 
        UpdateMuteButtonSprite();
    }

    public void SetVolume()
    {
        source.volume = volumeSlider.value;
        isMuted = source.volume == 0;
        source.mute = isMuted;
        UpdateMuteButtonSprite();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        source.mute = isMuted;

        if (isMuted)
        {
            volumeSlider.value = 0;
        }
        else
        {
            source.volume = 0.25f; // Restore volume when unmuted
            volumeSlider.value = source.volume;
        }

        UpdateMuteButtonSprite();
    }



    private void UpdateMuteButtonSprite()
    {
        if (muteButtonImage != null)
        {
            muteButtonImage.sprite = isMuted ? muteSprite : unmuteSprite;
        }
    }
}
