using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ESCENAS

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int lives = 3;
    private int score = 0;
    private int enemiesInLevel = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool PlayerDestroyed()
    {
        lives--;
        Debug.Log("VIDAS = " + lives);

        if (lives <= 0) //no quedan vidas
        {
            FinishLevel(false); //el jugador perdio el nivel
            return true; 
        }
        return false;
    }

    public void EnemyDestroyed(int destructionPoints)
    {
        enemiesInLevel--;
        Debug.Log("Enemigos = " + enemiesInLevel);

        score += destructionPoints;
        Debug.Log("PUNTUACION = " + score);
    }

    public void FinishLevel(bool playerWon)
    {
        if (playerWon)
        {
            Debug.Log("GANO");
        }
        else
        {
            Debug.Log("PERDIO");
        }
    }

    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddEnemy()
    {
        enemiesInLevel++;
        Debug.Log("Enemigos = "+ enemiesInLevel);
    }

   






}
