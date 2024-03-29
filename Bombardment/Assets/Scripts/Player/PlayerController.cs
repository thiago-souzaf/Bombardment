using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 10f;
    private void Update()
    {
        // Read Input
        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        // Create movement vector
        float movementX = isRight ? 1f : isLeft ? -1f : 0f;
        float movementZ = isUp ? 1f : isDown ? -1f : 0f;
        Vector3 movementVector = new Vector3(movementX, 0, movementZ);

        // Apply input to character
        transform.Translate(Time.deltaTime * movementSpeed * movementVector);
    }
}
