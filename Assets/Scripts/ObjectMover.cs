using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Range(0f, 10f)]
    public float scalar = 1;

    float xAmount;
    float yAmount;




    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Debug.Log($"{Time.time}, x = {xAmount}, y = {yAmount}");
    }

    void Update()
    {
        xAmount = Mathf.Cos(Time.time) * scalar ;
        yAmount = Mathf.Sin(Time.time) * scalar ;
        //xAmount = Mathf.Cos(Time.time * Mathf.Rad2Deg ) * scalar ;
        //yAmount = Mathf.Cos(Time.time * Mathf.Rad2Deg) * scalar ;

        this.transform.position = new Vector3(xAmount, this.transform.position.y, yAmount);
    }
}
