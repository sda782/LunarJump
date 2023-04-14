using System;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Action<GameObject> LevelComplete;
    private int currentLevel;
    private void Start() {
        LevelComplete += OnLevelComplete;
        currentLevel = 0;
    }
    private void OnLevelComplete(GameObject checkPoint) {
        checkPoint.SetActive(false);
        currentLevel++;
    }
    public int GetCurrentLevel { get => currentLevel; }

}
