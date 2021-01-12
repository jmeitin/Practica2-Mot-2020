using UnityEngine;

public class HeadQuarter : MonoBehaviour
{
    public Sprite deadEagle;

    private SpriteRenderer spriteact;
    private bool active = false; 

    private void Awake()
    {
        spriteact = GetComponent<SpriteRenderer>();
        if (spriteact == null) Debug.Log("HeadQuarter no tiene spriterenderer");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //CHOCA CON PLAYER
        if (collision.gameObject.GetComponent<PlayerController>() != null && spriteact != deadEagle)
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
        //CHOCA CON UNA BALA
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (spriteact.sprite != deadEagle)
            {
                spriteact.sprite = deadEagle;
                GameManager.GetInstance().FinishLevel(false);
            }
        }
    }
}
