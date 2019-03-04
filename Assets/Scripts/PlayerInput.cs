using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public float Horizontal, Vertical;
    public Vector3 MousePosition;
    public bool Shooting;

    void Update() {
        MousePosition = Input.mousePosition;
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        Shooting = Input.GetMouseButton(0);
    }
}