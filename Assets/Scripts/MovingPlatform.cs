using UnityEngine;
using UnityEngine.Splines.Interpolators;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float movingDistance;
    [SerializeField] private float pingpongSpeed;
    private Vector2 startPosition;
    private Vector2 endPosition;
    [SerializeField] private Vector2 velocity;
    public Vector2 passingVelocity => velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MovingSmoothly();
    }

    public void MovingSmoothly()
    {
        float u = Mathf.PingPong(Time.time * pingpongSpeed, 1f);
        float smoothU = Mathf.SmoothStep(0f, 1f, u);
        float deltaDistance = (smoothU * 2f - 1f) * movingDistance;
        Vector2 newPosition = startPosition + Vector2.right * deltaDistance;
        transform.position = newPosition;

        velocity =(newPosition-endPosition) / Time.deltaTime;
        endPosition = newPosition;
    }
}
