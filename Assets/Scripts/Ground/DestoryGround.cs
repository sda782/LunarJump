using UnityEngine;
using UnityEngine.U2D;

public class DestoryGround : MonoBehaviour {
    private const float localOffset = 2.8f;
    private Spline spline;
    private int numbersOfGridPoint = 20;
    private int offset = 28;

    void Start() {
        spline = GetComponent<SpriteShapeController>().spline;
        for (int i = 1; i < numbersOfGridPoint; i++) {
            float x = i * localOffset;
            Vector3 point = new Vector3(x - offset, 5);
            spline.InsertPointAt(i, point);
        }
        for (int i = 0; i < spline.GetPointCount(); i++) {
            Debug.Log($"index: {i}  position: {spline.GetPosition(i)}");
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag != "MoonPiece") return;
        Vector2 impactPoint = col.GetContact(0).point;
        int i = GetClosestIndexToPoint(impactPoint);
        MovePointDown(i);
        Destroy(col.gameObject);
    }

    private void MovePointDown(int index) {
        Vector2 point = spline.GetPosition(index) + Vector3.down;
        spline.SetPosition(index, point);
    }

    private int GetClosestIndexToPoint(Vector2 point) {
        float closestDist = 100000;
        int closestIndex = 0;
        for (int i = 0; i < spline.GetPointCount(); i++) {
            Vector2 p = spline.GetPosition(i);
            float dist = Vector2.Distance(point, p);
            if (dist >= closestDist) continue;
            Debug.Log(dist);
            closestDist = dist;
            closestIndex = i;
        }

        return closestIndex;
    }
}
