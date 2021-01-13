using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.GetInstance();
        gameManager.AddEnemy();
    }

   
}
