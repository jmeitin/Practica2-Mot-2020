using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxDamage;
    public int points = 100;

    private int damage = 0;
    private Vector2 pos;
    private Quaternion rotation;
    private PlayerController player;
    private GameManager gameManager;

    void Awake()
    {
        maxDamage = Mathf.Abs(maxDamage);
        pos = transform.position;
        rotation = transform.rotation;
        player = GetComponent<PlayerController>();
    }

    void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    public void MakeDamage()
    {
        damage++;

        if (damage >= maxDamage)
        {
            // ES UN ENEMIGO
            if (player == null)
            {                
                Destroy(this.gameObject);
                //Cuando los enemigos se destruyen solos
                gameManager.EnemyDestroyed(points);
            }
            else // ES EL PLAYER
            {
                if (gameManager != null) //PROTEGEMOS POR SI NO HAY GM
                {
                    //AUN LE QUEDAN VIDAS
                    if (!gameManager.PlayerDestroyed())
                    {
                        ReturnToOrigin();
                    }
                    else
                    {  // NO LE QUEDAN ==> SE DESTRUYE DEFINITIVAMENTE
                        Destroy(this.gameObject);
                    }
                }

                else
                {
                    ReturnToOrigin();
                }
            }
        }
    }
    private void ReturnToOrigin() // METODO AUXILIAR
    {
        transform.position = pos;
        transform.rotation = rotation;
        damage = 0;
    }

}
