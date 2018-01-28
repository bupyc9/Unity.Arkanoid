using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour, IGameManager {
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private string levelBGMusic;

    public float SoundVolume {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool SoundMute {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    private float musicVolume;
    public float MusicVolume {
        get {
            return musicVolume;
        }
        set {
            if (musicSource != null) {
                musicSource.volume = value;
            }

            musicVolume = value;
        }
    }

    public bool MusicMute {
        get {
            if (musicSource != null) {
                return musicSource.mute;
            }

            return false;
        }
        set {
            if (musicSource != null) {
                musicSource.mute = value;
            }
        }
    }

    public ManagerStatus status { get; private set; }

    public void Startup() {
        musicSource.ignoreListenerPause = true;
        musicSource.ignoreListenerVolume = true;

        SoundVolume = 1f;
        MusicVolume = 1f;

        PlayLevelMusic();

        status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip clip) {
        soundSource.PlayOneShot(clip);
    }

    public void PlayLevelMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic() {
        musicSource.Stop();
    }

    public void PlayLevelMusic() {
        PlayMusic(Resources.Load($"Music/{levelBGMusic}") as AudioClip);
    }

    private void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
