using UnityEngine;
using UnityEngine. SceneManagement;

public class Button : MonoBehaviour
{
    public void carregarEscena(string Nom)
    {
        SceneManager.LoadScene(Nom);
    }
}
