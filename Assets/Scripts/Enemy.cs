using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 100;
    void Start()
    {
        GameManager.instance.AddEnemy();
    }

    private void OnDestroy()
    {
        //Cuando los enemigos se destruyen solos
        GameManager.instance.EnemyDestroyed(points);
    }
}
