using UnityEngine;

public class HeadQuarter : MonoBehaviour
{
    public Sprite deadEagle;
    SpriteRenderer spriteact;
    bool active = false;
    private void Awake()
    {
        spriteact = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.GetComponent<PlayerController>() != null && spriteact != deadEagle)
        {
            if (!active)
            {
                GameManager.GetInstance().FinishLevel(true);
                active = true;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DestroyOnCollision>() != null)
        {
            if (spriteact.sprite != deadEagle)
            {
                spriteact.sprite = deadEagle;
                GameManager.GetInstance().FinishLevel(false);
            }
        }

    }
}
