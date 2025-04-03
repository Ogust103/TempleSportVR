using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider heightSlider;
    public void LoadGameScene()
    {
        PlayerData.height = heightSlider.value/100f;
        Debug.Log(PlayerData.height);
        SceneManager.LoadScene("Game"); // Replace with your game scene name
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu"); // Remplace "MenuScene" par le nom exact de ta scène du menu
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the application (only works in a built game)
    }
}
