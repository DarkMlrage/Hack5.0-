using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAtackVisuals : AtackVisual
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private GameObject flamePoint;
    [SerializeField] private float delay;
    [SerializeField] private float rotationSpeed;

    private Transform parentTransform;

    private void Start()
    {
        // Отримуємо посилання на трансформ батьківського об'єкта
        parentTransform = flamePoint.transform.parent;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            particleSystem.enableEmission = true;
        }
        else
        {
            particleSystem.enableEmission = false;
        }

    }

    public override void Visiualize()
    {
        StartCoroutine(VisualizeWithDelay());
    }

    private IEnumerator VisualizeWithDelay()
    {        
        yield return new WaitForSeconds(delay);        
    }


    private void FixedUpdate()
    {
        // Отримуємо позицію курсору мишки у світових координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Визначаємо вектор напрямку від батьківського об'єкта до курсору
        Vector3 direction = mousePosition - parentTransform.position;

        // Обчислюємо кут між напрямком та вектором вправо (1, 0)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Повертаємо батьківський об'єкт на знайдений кут
        parentTransform.rotation = Quaternion.Slerp(parentTransform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.fixedDeltaTime);
    }
}
