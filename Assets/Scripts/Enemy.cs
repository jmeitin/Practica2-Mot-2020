using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;

    void Start()
    {
        GameManager.instance.AddEnemy();
    }

    private void OnDestroy()
    {
        GameManager.instance.EnemyDestroyed(points);
    }
}
