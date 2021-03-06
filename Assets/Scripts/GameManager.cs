
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GameObject spirit;

	public int alive = 0;

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Update() {

        if(Input.GetKeyDown(KeyCode.R)){
            ResetLevel();
        }
		if(alive == 0) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        if(spirit != null) {
            spirit.transform.position = position;
            spirit.SetActive(true);
        }
    }
}