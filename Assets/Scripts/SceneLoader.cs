using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene"); // Replace with your game scene name
    }

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial_Demo"); // Replace with your tutorial scene name
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu"); // Remplace "MenuScene" par le nom exact de ta sc�ne du menu
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the application (only works in a built game)
    }
}
