using TMPro;
using UnityEngine;

public class TrashSpawner : MonoBehaviour {
    public GameObject[] compostItems;
    public GameObject[] recycleItems;
    public GameObject[] trashItems;
    public Vector2 spawnXRange = new(62f, 96f);
    public Vector2 spawnZRange = new(-2.4f, 32f); 
    public TMP_Text trashCounter;
    public float spawnY = 80f;
    public float spawnInterval = 2f; 
    public static int CurrentSpawns;

    void Start() {
        InvokeRepeating(nameof(SpawnRandomTrash), 1f, spawnInterval);
        trashCounter.SetText("Trash accumulated: 0");
    }

    void SpawnRandomTrash() {
        if (!LevelManager.IsPlaying) {
            return;
        }

        int category = Random.Range(0, 3);
        GameObject[] selectedItems = category switch {
            0 => compostItems,
            1 => recycleItems,
            2 => trashItems,
            _ => null
        };

        if (selectedItems != null && selectedItems.Length > 0) {
            SpawnTrash(selectedItems);
        }
    }

    void SpawnTrash(GameObject[] objects) {
        int randomIndex = Random.Range(0, objects.Length);
        GameObject randomObject = objects[randomIndex];

        Vector3 spawnPosition = new(Random.Range(spawnXRange.x, spawnXRange.y), spawnY, Random.Range(spawnZRange.x, spawnZRange.y));

        Instantiate(randomObject, spawnPosition, Quaternion.identity);
        CurrentSpawns++;
        trashCounter.SetText("Trash accumulated: " + CurrentSpawns.ToString());
    }
}

