using System;
using UnityEngine;
using UnityEngine.TextCore;

public class TrashDeposit : MonoBehaviour {
    public string correctTrashType;
    public string incorrectTrashType1;
    public string incorrectTrashType2;
    public AudioClip acceptSFX;
    public AudioClip denySFX;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null) {
            if (other.CompareTag(correctTrashType)){
                if (other.transform.parent.name == "Red Player") {
                    PlaySoundClip(acceptSFX);
                    LevelManager.RedScore++;
                    TrashSpawner.CurrentSpawns--;
                } else if(other.transform.parent.name == "Blue Player") {
                    PlaySoundClip(acceptSFX);
                    LevelManager.BlueScore++;
                    TrashSpawner.CurrentSpawns--;
                }
                Destroy(other.gameObject);
            } else if (other.CompareTag(incorrectTrashType1) || other.CompareTag(incorrectTrashType2)) {
                if (other.transform.parent.name == "Red Player") {
                    PlaySoundClip(denySFX);
                    LevelManager.RedScore--;
                    TrashSpawner.CurrentSpawns--;
                } else if (other.transform.parent.name == "Blue Player") {
                    PlaySoundClip(denySFX);
                    LevelManager.BlueScore--;
                    TrashSpawner.CurrentSpawns--;
                }
                Destroy(other.gameObject);
            }
            if (LevelManager.RedScore < 0){
                LevelManager.RedScore = 00;
            }
            
            if (LevelManager.BlueScore < 0){
                LevelManager.BlueScore = 00;
            }
        }
    }

    void PlaySoundClip(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
