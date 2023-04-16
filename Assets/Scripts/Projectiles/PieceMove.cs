using UnityEngine;

public class PieceMove : MonoBehaviour {

    public void Move(Vector2 direction) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D col) {
        switch (col.gameObject.tag) {
            case "Border":
            case "Player":
                Destroy(gameObject);
                break;
        }
    }
}
