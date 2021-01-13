using UnityEngine;

public class HeadQuarter : MonoBehaviour
{
    public Sprite deadEagle;
    private SpriteRenderer spriteact;
    private PlayerController playercontrol;
    private bool active = false;
    private GameManager gameManager;

    private void Awake()
    {
        spriteact = GetComponent<SpriteRenderer>();
        if (spriteact == null) Debug.Log("HeadQuarter no tiene spriterenderer");
    }

    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //CHOCA CON PLAYER
        if (collision.gameObject.GetComponent<PlayerController>() != null && spriteact != deadEagle)
        {
            playercontrol = collision.gameObject.GetComponent<PlayerController>();
            if (!active)
            {
                playercontrol.BlockControls();
                active = true;
                gameManager.FinishLevel(true);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //CHOCA CON UNA BALA
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            playercontrol = collision.gameObject.GetComponent<PlayerController>();
            if (spriteact.sprite != deadEagle)
            {
                spriteact.sprite = deadEagle;
                gameManager.FinishLevel(false);
                playercontrol.BlockControls();
            }
        }
    }
}
