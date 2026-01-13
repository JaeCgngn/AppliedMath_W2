using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;


    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
        
    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
