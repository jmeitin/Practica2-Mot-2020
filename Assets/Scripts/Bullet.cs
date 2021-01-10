using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocityScale = 8f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.Log("Bullet no tiene Rigidbody");
        velocityScale = Mathf.Abs(velocityScale);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * velocityScale;
    }
}
