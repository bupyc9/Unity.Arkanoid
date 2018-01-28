using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSettings : MonoBehaviour {
    [SerializeField] private GameObject overlay;
    [SerializeField] private ToggleSprite muteButton;

    private void Start() {
        Close();
    }

    public void Close() {
        gameObject.SetActive(false);
        overlay.SetActive(false);
    }

    public void Open() {
        gameObject.SetActive(true);
        overlay.SetActive(true);
    }

    public void OnSoundValue(Slider slider) {
        Managers.Audio.SoundVolume = slider.value;
    }

    public void OnMusicToggle() {
        muteButton.IsOn = !muteButton.IsOn;
        Managers.Audio.MusicMute = !Managers.Audio.MusicMute;
    }

    public void OnMusicValue(Slider slider) {
        Managers.Audio.MusicVolume = slider.value;
    }
}
