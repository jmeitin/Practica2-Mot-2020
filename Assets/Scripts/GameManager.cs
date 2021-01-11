using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ESCENAS

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string[] scenesInOrder;

    private int stage; //Comprobar en que nivel estamos 

    private int lives = 3;
    private int levelScore = 0, sessionScore;
    private int enemiesInLevel = 0;
    private UiManager theUIManager;



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
        stage = SceneManager.GetActiveScene().buildIndex; //Obtenemos el valor de stage antes de pasar al siguiente nivel 
    }

    public void SetUIManager(UiManager uim)
    {
        theUIManager = uim;
        uim.Init(lives, enemiesInLevel, 0);
    }

    public bool PlayerDestroyed()
    {
        lives--;
        if (theUIManager != null) theUIManager.UpdateLives(lives); //codigo defensivo

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
        if (theUIManager != null) theUIManager.RemoveEnemy(levelScore);
        levelScore += destructionPoints;
        
    }

    public void FinishLevel(bool playerWon)
    {       
        sessionScore += levelScore;
        theUIManager.Score(levelScore, sessionScore, stage, playerWon);

        if (playerWon) Invoke("NextLevel", 3);
        else Invoke("GameOver", 3);


    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddEnemy()
    {
        enemiesInLevel++;
    }
    private void GameOver()
    {
        //Quitamos los puntos , ponemos 3 vidas al jugador y volvemos a la primera escena 
        levelScore = 0;
        sessionScore = 0;
        lives = 3;
        stage = 0;
        //Como hemos perdido vamos al menu 
        ChangeScene(scenesInOrder[0]);
    }
    void NextLevel()
    {
        stage++; //Avanzamos de Nivel 
        if (stage < scenesInOrder.Length) //Ver si es el ultimo nivel 
        {
            ChangeScene(scenesInOrder[stage]);
        }
        else GameOver();
    }
    void OnLevelWasLoaded(int level)
    {
        levelScore = 0;
    }
}
