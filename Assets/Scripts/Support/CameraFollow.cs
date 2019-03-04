using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float SmoothTime = 0.3f;
    private Vector3 currentVelocity;

    void LateUpdate() {
        transform.position =
            Vector3.SmoothDamp(transform.position, calculatePlayerPosition(), ref currentVelocity, SmoothTime);
    }

    private Vector3 calculatePlayerPosition() {
        if (GameManager.Instance.Player == null) {
            return Vector3.zero;
        }

        // TODO if we going fast in one direction last x milliseconds we should look further than actual target.position
        return GameManager.Instance.Player.transform.position;
    }
}