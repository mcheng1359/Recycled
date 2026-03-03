using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    private AudioSource musicSource;
    private AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip hoverSFX;
    public AudioClip decideSFX;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene changes
        } else {
            Destroy(gameObject);
            return;
        }

        musicSource = gameObject.AddComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.volume = 0.25f;
        audioSource.volume = 0.75f;

        PlayMusic();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        RestartMusic(); // Restart music when a new scene loads
    }

    public void PlayMusic() {
        if (backgroundMusic != null) {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void RestartMusic() {
        if (musicSource.isPlaying) {
            musicSource.Stop(); // Stop the current music
        }
        PlayMusic(); // Start fresh music for the new scene
    }

    public void PlayHoverSound() {
        if (hoverSFX != null) {
            audioSource.PlayOneShot(hoverSFX);
        }
    }

    public void PlayDecideSound() {
        if (decideSFX != null) {
            audioSource.PlayOneShot(decideSFX);
        }
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to prevent memory leaks
    }
}
