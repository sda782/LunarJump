using System;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Action<GameObject> LevelComplete;
    private void Start() {
        LevelComplete += OnLevelComplete;
    }
    private void OnLevelComplete(GameObject checkPoint) {
        checkPoint.SetActive(false);
    }

}
