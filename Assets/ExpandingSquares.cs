using UnityEngine;

public class ExpandingSquares : MonoBehaviour
{
    public float speed = 5f; // The speed of the object
    public float driftSpeed = 2.8f; // The speed at which the object drifts off course
    public float expandRate = 0.5f; // The rate at which the square expands
    private float squareSize = 1f; // The initial size of the square

    private Vector2[] corners = new Vector2[4]; // The corners of the square
    private int currentCorner = 0; // The current corner the object is moving towards
    private Vector2 targetPosition; // The position of the next corner

    void Start()
    {
        // Get the corners of the square
        corners[0] = new Vector2(transform.position.x - squareSize / 2f, transform.position.y - squareSize / 2f);
        corners[1] = new Vector2(transform.position.x + squareSize / 2f, transform.position.y - squareSize / 2f);
        corners[2] = new Vector2(transform.position.x + squareSize / 2f, transform.position.y + squareSize / 2f);
        corners[3] = new Vector2(transform.position.x - squareSize / 2f, transform.position.y + squareSize / 2f);

        // Set the target position to the first corner
        targetPosition = corners[currentCorner];
    }

    void Update()
    {
        // Move towards the target position
        Vector2 direction = targetPosition - (Vector2)transform.position;
        direction.Normalize();
        transform.position += (Vector3)((direction * speed) + (Random.insideUnitCircle * driftSpeed)) * Time.deltaTime;

        // If the object reaches the target position, select the next corner
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentCorner = (currentCorner + 1) % 4;
            targetPosition = corners[currentCorner];

            // Increase the square size
            squareSize += expandRate;
            corners[0] = new Vector2(transform.position.x - squareSize / 2f, transform.position.y - squareSize / 2f);
            corners[1] = new Vector2(transform.position.x + squareSize / 2f, transform.position.y - squareSize / 2f);
            corners[2] = new Vector2(transform.position.x + squareSize / 2f, transform.position.y + squareSize / 2f);
            corners[3] = new Vector2(transform.position.x - squareSize / 2f, transform.position.y + squareSize / 2f);
        }
    }
}
