using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        
        if (damageable != null)
        {
            damageable.MakeDamage();
        }
       
        Destroy(this.gameObject);
    }
}
