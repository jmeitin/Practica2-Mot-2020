using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>()!= null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("El muro choco con algo que no era una bala");
        }
    }
}
