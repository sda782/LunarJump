using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour {
    [SerializeField] private Countdown countdown;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private WaterRising waterRising;
    [SerializeField] private SinkingCity sinkingCity;
    [SerializeField] private BallonPopping ballonPopping;
    [SerializeField] private Beathing beathing;
    private List<BaseObstacles> obstacles = new List<BaseObstacles>();
    void Start() {
        obstacles.Add(waterRising);
        obstacles.Add(sinkingCity);
        obstacles.Add(ballonPopping);
        obstacles.Add(beathing);
        countdown.CountdownTrigger += ActivateObstacle;
    }

    public void ActivateObstacle() {
        obstacles[levelManager.GetCurrentLevel].init();
    }
}
