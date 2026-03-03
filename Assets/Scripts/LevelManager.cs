using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static bool IsPlaying {get; private set;}   
    public static int BlueScore = 00;
    public static int RedScore = 00; 
    public float levelTime = 60;
    public int maxSpawns;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    public TMP_Text timerText;
    public TMP_Text gameTitleText;
    public TMP_Text gameCaptionText;
    public TMP_Text blueScore;
    public TMP_Text redScore;
    public Image background;
    public GameObject replay;
    private float countdown;
    private AudioSource audioSource;
    
    void Start() {
        IsPlaying = true;
        BlueScore = 00;
        RedScore = 00;
        countdown = levelTime;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (!IsPlaying) return;
        
        LevelTimer();
        SetTimerText();
        SetScoreText();

        if (TrashSpawner.CurrentSpawns > maxSpawns) {
            LevelLose();
        }

        if (countdown <= 0) {
            if (BlueScore > RedScore) {
                Debug.Log("win");
                LevelWin("Blue"); 
            } else if (RedScore > BlueScore) {
                Debug.Log("lose");
                LevelWin("Red");
            } else {
                Debug.Log("tie");
                LevelTie();
            }
        }
    }

    void LevelTimer() {
        countdown -= Time.deltaTime;

        if (countdown <= 0) {
            countdown = 0;
        }
    }
    
    void SetTimerText() { timerText.text = countdown.ToString("0"); }

    void LevelLose() {
        IsPlaying = false;
        PlaySoundClip(loseSFX);
        DisplayTitle("Game Over!");
        DisplayCaption("Too much trash accumulated on the map :("); 
        DisplayUI();       
    }

    void LevelWin(string color) {
        IsPlaying = false;
        PlaySoundClip(winSFX);
        DisplayTitle("The park is cleaner!");
        DisplayCaption($"Player {color} collected more trash!");
        DisplayUI();
    }

    void LevelTie() {
        IsPlaying = false;
        PlaySoundClip(winSFX);
        DisplayTitle("The park is cleaner!");
        DisplayCaption("It's a tie, but still a win-win!");
        DisplayUI();
    }
    
    void DisplayTitle(string message) {
        if (gameTitleText) {
            gameTitleText.text = message;
            gameTitleText.enabled = true;
        }
    } 

    void DisplayCaption(string message) {
        if (gameCaptionText) {
            gameCaptionText.text = message;
            gameCaptionText.enabled = true;
        }
    }

    void DisplayUI() {
        background.enabled = true;
        replay.SetActive(true);
    }

    void PlaySoundClip(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }

    void SetScoreText(){
        if (RedScore < 10) {
            redScore.text = "0" + RedScore.ToString();
        } else {
            redScore.text = RedScore.ToString();
        }

        if (BlueScore < 10) {
            blueScore.text = "0" + BlueScore.ToString();
        } else {
            blueScore.text = BlueScore.ToString();
        }

    }

    void ResetScore() {
        BlueScore = 00;
        RedScore = 00; 
        TrashSpawner.CurrentSpawns = 0;
    }

    public void ReplayLevel() {
        ClearGameResults();
        ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ClearGameResults() {
        if (gameTitleText) {
            gameTitleText.text = "";
            gameTitleText.enabled = false;
        }

        if (gameCaptionText) {
            gameCaptionText.text = "";
            gameCaptionText.enabled = false;
        }

        background.enabled = false;
        replay.SetActive(false);
    }
}
