using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PlayHoverSound() {
        if (SoundManager.Instance != null) {
            SoundManager.Instance.PlayHoverSound();
        }
    }
}
