
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField] private LevelManager levelManager;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Goal") {
            levelManager.LevelComplete?.Invoke();
            Destroy(col.gameObject);
        }
    }
}
