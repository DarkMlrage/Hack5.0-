using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Button continueButton;

    public void NewGame()
    {
        SceneManager.LoadScene("Introduciton");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Introduciton");//TODO
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}