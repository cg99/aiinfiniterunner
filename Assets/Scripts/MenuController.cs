using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
     public GameObject menuPanel;
     public PlayerController playerController;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");

        playerController.StartRunning();

         // Disable the menu UI
        menuPanel.SetActive(false);


    }
}
