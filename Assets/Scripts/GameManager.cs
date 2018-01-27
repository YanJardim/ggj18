
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GameObject spirit;

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            ResetLevel();
        }
    }

    public void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(this);
        }
    }

    public void SpawnSpirit(Vector2 position) {
        spirit.transform.position = position;
        spirit.SetActive(true);
    }
}