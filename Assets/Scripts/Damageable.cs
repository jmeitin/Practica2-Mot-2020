using System.Collections;
using System.Collections.Generic;
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
                if (GameManager.instance != null) //PROTEGEMOS POR SI NO HAY GM
                {
                    //AUN LE QUEDAN VIDAS
                    if (!GameManager.instance.PlayerDestroyed())
                    {
                        ReturnToOirigin();
                    }
                    else
                    {  // NO LE QUEDAN ==> SE DESTRUYE DEFINITIVAMENTE
                        Destroy(this.gameObject);
                    }
                }

                else
                {
                    ReturnToOirigin();
                }
                 
                
            }
          
        }
    }

    private void ReturnToOirigin() // METODO AUXILIAR
    {
        transform.position = pos;
        transform.rotation = rotation;
        damage = 0;
    }
    
}
