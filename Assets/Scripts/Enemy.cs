using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 100;
    void Start()
    {
        GameManager.GetInstance().AddEnemy();
    }

    private void OnDestroy()
    {
        //Cuando los enemigos se destruyen solos
        GameManager.GetInstance().EnemyDestroyed(points);
    }
}
