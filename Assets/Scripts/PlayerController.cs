using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocityScale = 5f;

    private Rigidbody2D rb;
    private Vector2 valueUp;
    private Shooter shooter;
    bool block= false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.Log("Player no tiene Rigidbody");

        valueUp = Vector2.zero;
        velocityScale = Mathf.Abs(velocityScale);

        shooter = GetComponentInChildren<Shooter>();
        if (shooter == null) Debug.Log("Player no encontro el shooter");
    }

    void Update()
    {
        if (!block)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                valueUp = new Vector2(0, 1);
                transform.up = Vector2.up;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                valueUp = new Vector2(0, -1);
                transform.up = Vector2.down;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                valueUp = new Vector2(1, 0);
                transform.up = Vector2.right; //transform.up?
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                valueUp = new Vector2(-1, 0);
                transform.up = Vector2.left;
            }
            else
            {
                valueUp = Vector2.zero;
            }
            if (Input.GetButton("Jump"))
            {
                shooter.Shoot();
            }
        }
        else valueUp = Vector2.zero;

    }

    void FixedUpdate()
    {
        rb.velocity = velocityScale * valueUp;
    }
    public void BlockControls() { block = true; }
   
}
