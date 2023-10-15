using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTimer : MonoBehaviour
{
    [SerializeField]
    private float countdownTime = 8.5f; // Час таймера в секундах
    [SerializeField]
    private int sceneToLoad = 0; // Назва сцени, яку потрібно відкрити

    private bool isTimerActive = false;

    private void Start()
    {
        // Розпочинаємо таймер при запуску
        StartCountdown();
    }

    public void StartCountdown()
    {
        isTimerActive = true;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(countdownTime);

        // Виконуємо дії, коли таймер завершено
        LoadScene();
    }

    private void LoadScene()
    {
        // Завантажуємо сцену з вказаною назвою
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
