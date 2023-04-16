using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    private readonly float startTime = 10.5f;
    private readonly float timerGracePeriod = 5f;

    private float currentTime;

    private bool gracePeriod;

    [SerializeField]
    private TMP_Text timerTextField;
    [SerializeField] private Slider countDownSlider;

    public Action CountdownTrigger;

    private void Awake() {
        //timerTextField.text = $"{startTime:0.#}";
        currentTime = startTime;
        countDownSlider.value = 1;
    }

    private void Start() {
        CountdownTrigger?.Invoke();
    }

    private void Update() {
        if (gracePeriod) { return; }

        currentTime -= Time.deltaTime;

        //timerTextField.text = $"{currentTime:0}";
        float scaledValue = currentTime / startTime;
        countDownSlider.value = scaledValue;

        if (currentTime <= 0) {

            StartCoroutine(RestartTimer());
        }
    }

    private IEnumerator RestartTimer() {
        //Wait for 5 sec
        gracePeriod = true;
        //timerTextField.enabled = false;

        yield return new WaitForSeconds(timerGracePeriod);

        gracePeriod = false;
        currentTime = startTime;

        countDownSlider.value = 1;
        CountdownTrigger?.Invoke();
        //timerTextField.enabled = true;
    }
}
