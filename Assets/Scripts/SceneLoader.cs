using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); // Replace with your game scene name
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Game"); // Remplace "MenuScene" par le nom exact de ta scène du menu
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the application (only works in a built game)
    }
}
