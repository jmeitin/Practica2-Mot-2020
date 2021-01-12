using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxDamage;

    private int damage = 0;
    private Vector2 pos;
    private Quaternion rotation;
    private PlayerController player;

    void Awake()
    {
        maxDamage = Mathf.Abs(maxDamage);
        pos = transform.position;
        rotation = transform.rotation;
        player = GetComponent<PlayerController>();
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
            }

            else // ES EL PLAYER
            {
                if (GameManager.GetInstance() != null) //PROTEGEMOS POR SI NO HAY GM
                {
                    //AUN LE QUEDAN VIDAS
                    if (!GameManager.GetInstance().PlayerDestroyed())
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
