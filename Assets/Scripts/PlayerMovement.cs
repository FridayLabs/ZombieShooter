using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour {
    public float MovementSpeed = 10f;

    private Vector3 forward, right;
    private PlayerInput input;
    private CharacterController characterController;
    private Camera cam;

    void Start() {
        input = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        calculateMovementVectors();
    }

    private void calculateMovementVectors() {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update() {
        if (Input.anyKey) {
            handleMovement();
        }

        handleRotation();
    }

    private void handleRotation() {
        Ray ray = Camera.main.ScreenPointToRay(input.MousePosition);
        RaycastHit rayCastHit;
        if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity)) {
            Vector3 hit = rayCastHit.point;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(input.MousePosition);
            float total = hit.y - mouseWorldPos.y;
            float newY = total - (hit.y - transform.position.y);
            float factor = newY / total;
            Vector3 target = mouseWorldPos + ((hit - mouseWorldPos) * factor);
            transform.LookAt(target);
        }
    }

    private void handleMovement() {
        Vector3 rightMovement = right * input.Horizontal * Time.deltaTime;
        Vector3 forwardMovement = forward * input.Vertical * Time.deltaTime;

        characterController.SimpleMove(Vector3.Normalize(rightMovement + forwardMovement) * MovementSpeed);
    }
}