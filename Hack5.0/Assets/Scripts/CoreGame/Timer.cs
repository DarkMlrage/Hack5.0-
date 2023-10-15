using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTimer : MonoBehaviour
{
    [SerializeField]
    private float countdownTime = 8.5f; // ��� ������� � ��������
    [SerializeField]
    private int sceneToLoad = 0; // ����� �����, ��� ������� �������

    private bool isTimerActive = false;

    private void Start()
    {
        // ����������� ������ ��� �������
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

        // �������� 䳿, ���� ������ ���������
        LoadScene();
    }

    private void LoadScene()
    {
        // ����������� ����� � �������� ������
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
