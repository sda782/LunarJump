using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour {
    private readonly float startTime = 10.5f;
    private readonly float timerGracePeriod = 5f;

    private float currentTime;

    private bool gracePeriod;

    [SerializeField]
    private TMP_Text timerTextField;

    public Action CountdownTrigger;

    private void Awake() {
        timerTextField.text = $"{startTime:0.#}";
        currentTime = startTime;
    }

    private void Update() {
        if (gracePeriod) { return; }

        currentTime -= Time.deltaTime;

        timerTextField.text = $"{currentTime:0}";

        if (currentTime <= 0) {
            CountdownTrigger?.Invoke();
            StartCoroutine(RestartTimer());
        }
    }

    private IEnumerator RestartTimer() {
        //Wait for 5 sec
        gracePeriod = true;
        timerTextField.enabled = false;

        yield return new WaitForSeconds(timerGracePeriod);

        gracePeriod = false;
        currentTime = startTime;

        timerTextField.enabled = true;
    }
}
