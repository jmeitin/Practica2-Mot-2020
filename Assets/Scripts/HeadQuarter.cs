using UnityEngine;

public class HeadQuarter : MonoBehaviour
{
    public Sprite destroyedSprite;
    private SpriteRenderer srenderer;

    void Awake()
    {
        srenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ES EL PLAYER
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.GetInstance().FinishLevel(true); //GANO
        }
        //ES UNA BALA
        else if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            GameManager.GetInstance().FinishLevel(false); //PERDIO
            srenderer.sprite = destroyedSprite;
        }
    }
}
