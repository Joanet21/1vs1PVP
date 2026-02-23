using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText1;
    public TMP_Text scoreText2;
    public TMP_Text Guanyador;

    public int score1 = 0;
    public int score2 = 0;
    public static class GameData
    {
        public static string guanyadorr;
    }

    void Start()
    {

    }

    void Update()
    {
       UpdateUI();
        if (score1 == 20)
        {
            GameData.guanyadorr = "cap de Carbassa";
            SceneManager.LoadScene("Final");

        }
        UpdateUI();
        if (score2 == 20)
        {
            GameData.guanyadorr = "Cavaller";
            SceneManager.LoadScene("Final");
        }
    }

    public void AddScore1()
    {
        score1++;
        UpdateUI();
    }

    public void AddScore2()
    {
        score2++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText1 != null) scoreText1.text = $"Carbaça: {score1}";
        if (scoreText2 != null) scoreText2.text = $"Caballer: {score2}";
    }


}