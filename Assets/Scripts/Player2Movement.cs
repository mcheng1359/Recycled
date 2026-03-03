using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 2f;
    private float gravity = -9.81f;
    private bool isGrounded;
    private CharacterController controller;
    private Vector3 velocity;
    
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        float moveX = 0;
        float moveZ = 0;
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

            if (Input.GetKey(KeyCode.LeftArrow)) {
                moveX = -1f;
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                moveX = 1f;
            } else {
                moveX = 0f;
            }

            if (Input.GetKey(KeyCode.UpArrow)) {
                moveZ = 1f;
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                moveZ = -1f;
            } else {
                moveZ = 0f;
            }

            Vector3 move = new(moveX, 0, moveZ);
            move.Normalize();
            transform.Translate(speed * Time.deltaTime * move, Space.World);
            controller.Move(speed * Time.deltaTime * move);

            if (move != Vector3.zero) {
                Quaternion rotate = Quaternion.LookRotation(move, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, 720 * Time.deltaTime);
            }

        if (Input.GetKey(KeyCode.RightShift) && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}