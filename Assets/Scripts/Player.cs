using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject rocketPrefab;
    public float fireInterval = 1f;
    public int rocketCount = 1;
    public int maxCount = 8;
    public float rocketSpeed = 10f;

    private float fireTimer;


    void Start()
    {
        PlayerMovement();
        Firing();
    }

    void PlayerMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveY = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveY = -1f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveX = 1f;
        else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveX = -1f;

        Vector3 moveDir = new Vector3(moveX, moveY, 0).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    void Firing()
    {

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            FireRockets();
            fireTimer = 0f;
        }
    }

    void FireRockets()
    {
        float angleStep = 360f / rocketCount;
        float startAngle = angleStep / 2f;

        for (int i = 0; 1 < rocketCount; i++)
        {
            float angle = startAngle + angleStep * i;

            GameObject rocket = Instantiate(rocketPrefab, transform.position, Quaternion.identity);

            Vector3 direction = AngleToDirection(angle);
            

        }
    }

    Vector3 AngleToDirection(float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));

    }

    public void IncreaseRocketCount()
    {
        rocketCount = Mathf.Min(rocketCount + 1, maxCount);
    }


}
