using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public TextMeshProUGUI killCountText; // Посилання на TextMeshPro текстове поле для виводу лічильника.

    private int killCount = 0; // Початкове значення лічильника.

    private static KillCount instance;

    public static KillCount Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KillCount>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateKillCountText();
    }

    public void IncrementKillCount()
    {
        killCount++;
        UpdateKillCountText();
    }

    private void UpdateKillCountText()
    {
        killCountText.text = killCount.ToString("D4"); // Форматуємо число на виведення з завжди чотирма цифрами.
    }
}
