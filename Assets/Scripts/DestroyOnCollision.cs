using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        
        if (damageable != null) // si es un objeto que recibe danyo
        {
            damageable.MakeDamage();
        }
       
        Destroy(this.gameObject);
    }
}
