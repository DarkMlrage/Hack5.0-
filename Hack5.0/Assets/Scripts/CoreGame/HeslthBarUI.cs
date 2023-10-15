using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    [SerializeField] private Slider slider; // ��������� �� ��'��� ��������.
    [SerializeField] private float minValue = 0f; // ̳������� �������� ��������.
    [SerializeField] private float maxValue = 1f; // ����������� �������� ��������.    

    private Player player;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        // ������ �������� �� ����������� �������� �������� ��� �������.
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        
    }

    private void FixedUpdate()
    {        
        slider.value = player.health;
    }
}
