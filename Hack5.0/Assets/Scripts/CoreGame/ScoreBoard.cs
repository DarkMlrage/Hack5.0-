using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public TextMeshProUGUI killCountText; // ��������� �� TextMeshPro �������� ���� ��� ������ ���������.

    private int killCount = 0; // ��������� �������� ���������.

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
        killCountText.text = killCount.ToString("D4"); // ��������� ����� �� ��������� � ������ ������� �������.
    }
}
