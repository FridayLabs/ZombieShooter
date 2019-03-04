using UnityEngine;

public class Billboard : MonoBehaviour {
    Camera targetCamera;

    void Start() {
        targetCamera = Camera.main;
    }

    void LateUpdate() {
        transform.rotation = targetCamera.transform.rotation;
    }
}