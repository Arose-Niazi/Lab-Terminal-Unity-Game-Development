using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
    
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
