using UnityEngine;

public class TEMP_MoonPieces : MonoBehaviour {
    [SerializeField] private GameObject moonPiecePrefab;
    void Update() {
        if (Input.GetMouseButtonDown(0)) SpawnMoonPiece();
    }

    private void SpawnMoonPiece() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject moonPiece = Instantiate(moonPiecePrefab, mousePosition, moonPiecePrefab.transform.rotation);
    }
}
