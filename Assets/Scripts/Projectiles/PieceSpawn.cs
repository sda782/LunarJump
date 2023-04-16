using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawn : MonoBehaviour {
    [SerializeField] private Countdown countdown;
    [SerializeField] private GameObject moonPiecePrefab;
    private int numberOfPieces = 20;

    private void Start() {
        countdown.CountdownTrigger += OnCountdown;
    }

    private void OnCountdown() {
        StartCoroutine("SpawnProjectile");
    }
    private IEnumerator SpawnProjectile() {
        for (int i = 0; i < numberOfPieces; i++) {
            GameObject piece = Instantiate(moonPiecePrefab, transform);
            piece.GetComponent<PieceMove>().Move(GetRandomDirection());
            Destroy(piece, 5);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    private Vector2 GetRandomDirection() {
        float x = Random.Range(-20, 21);
        Vector2 dir = new Vector2(x, 0);
        return dir;
    }
}
