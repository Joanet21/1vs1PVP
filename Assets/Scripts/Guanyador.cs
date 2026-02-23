using TMPro;
using UnityEngine;
using static ScoreManager;

public class Guanyador : MonoBehaviour
{
    public TMP_Text Guanyadortext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Guanyadortext.text = "Guanyador: " + GameData.guanyadorr;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
