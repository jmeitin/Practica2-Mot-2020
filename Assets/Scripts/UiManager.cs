using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //CANVAS

public class UiManager : MonoBehaviour
{
    public Text livesText;
    public Image enemyIconPrefab;
    public RectTransform enemiesPanel;
    public Text stageText;
    public Text levelScoreText;
    public Text sessionScoreText;
    public GameObject infoPanel;
    public GameObject gameOverPanel;


    private int enemiesLeft;

    void Start()
    {
        GameManager.instance.SetUIManager(this);
        // enemiesLeft = 0;
    }

    public void Init(int numLives, int numEnemies, int levelScore)
    {
        livesText.text = numLives.ToString();
        enemiesLeft = numEnemies;
        Debug.Log("ENEMIESLEFT INIT = " + enemiesLeft);

        for (int i = 0; i < numEnemies; i++)
        {
            Image enemy = Instantiate(enemyIconPrefab);
            enemy.rectTransform.SetParent(enemiesPanel); //transform o rectTransform?
        }

    }

    public void UpdateLives(int numLives)
    {
        livesText.text = numLives.ToString();
    }

    public void RemoveEnemy(int levelScore)
    {
        Debug.Log("ENEMIESLEFT = " + enemiesLeft);
        if (enemiesLeft > 0)
        {
            if (enemiesPanel != null)
            {
                enemiesPanel.GetChild(enemiesLeft - 1).gameObject.SetActive(false);
                enemiesPanel.GetChild(enemiesLeft - 1).gameObject.SetActive(false);
            }

            enemiesLeft--;
        }
        Debug.Log("ENEMIESLEFT = " + enemiesLeft);
    }

    public void Score(int levelScore, int sessionScore, int level, bool playing)
    {

    }
}
