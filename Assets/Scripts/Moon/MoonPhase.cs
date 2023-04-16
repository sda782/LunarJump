using UnityEngine;

public class MoonPhase : MonoBehaviour {
    [SerializeField] private Transform moon;
    [SerializeField] private Transform cutoff;
    [SerializeField] private Countdown countdown;
    void Start() {
        cutoff.localPosition = new Vector3(1.1f, 0);
        countdown.CountdownTrigger += MoveCutoff;
    }

    private void MoveCutoff() {
        cutoff.localPosition += new Vector3(-0.11f, 0);
    }
}
