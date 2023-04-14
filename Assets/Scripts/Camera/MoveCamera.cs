
using System;
using System.Collections;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    [SerializeField] private int offset = 25;
    [SerializeField] private float speed;
    [SerializeField] private LevelManager levelManager;
    public Action MoveCameraDown;

    void Start() {
        levelManager.LevelComplete += ShiftCamera;

    }
    private void ShiftCamera(GameObject obj) {
        float target = transform.position.y + offset;
        StartCoroutine("Move", target);
    }
    private void ShiftCameraDown() {
        StopAllCoroutines();
        float target = transform.position.y - offset;
        StartCoroutine("MoveCamera", target);
    }
    private IEnumerator Move(float target) {
        while (transform.position.y < target) {
            transform.position += new Vector3(0, Time.deltaTime * speed);
            yield return null;
        }
        yield break;
    }
}
