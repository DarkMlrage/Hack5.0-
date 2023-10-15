using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    [SerializeField] private Slider slider; // Посилання на об'єкт слайдера.
    [SerializeField] private float minValue = 0f; // Мінімальне значення слайдера.
    [SerializeField] private float maxValue = 1f; // Максимальне значення слайдера.    

    private Player player;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        // Задаємо мінімальне та максимальне значення слайдера при запуску.
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        
    }

    private void FixedUpdate()
    {        
        slider.value = player.health;
    }
}
