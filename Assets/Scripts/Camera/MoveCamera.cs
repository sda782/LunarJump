
using System.Collections;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    [SerializeField] private const int offset = 25;
    [SerializeField] private LevelManager levelManager;
    private float speed = 2;

    void Start() {
        levelManager.LevelComplete += ShiftCamera;
    }
    private void ShiftCamera() {
        float target = transform.position.y + offset;
        StartCoroutine("Move", target);
    }
    private IEnumerator Move(float target) {
        while (transform.position.y < target) {
            transform.position += new Vector3(0, Time.deltaTime * speed);
            yield return null;
        }
        yield break;
    }
}
