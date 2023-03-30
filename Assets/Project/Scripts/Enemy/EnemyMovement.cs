using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float timeToChangeDirection = 10f;

    private Vector3 initalPosition;
    private float timeElapsed = 0f;

    private void Start()
    {
        initalPosition = transform.position;
    }

    private void Update()
    {
        Movement();

    }

    private void Movement()
    {
        Vector3 forwardDirection = transform.forward;

        transform.position = transform.position + forwardDirection * speed * Time.deltaTime;

        timeElapsed = timeElapsed + Time.deltaTime;

        if (timeElapsed >= timeToChangeDirection)
        {
            float randomAngle = UnityEngine.Random.Range(0f, 360f);

            transform.rotation = Quaternion.Euler(0, randomAngle, 0);

            initalPosition = transform.position;

            timeElapsed = 0f;

        }
    }
}


