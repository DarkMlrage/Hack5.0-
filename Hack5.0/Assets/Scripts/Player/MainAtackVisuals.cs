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
        // �������� ��������� �� ��������� ������������ ��'����
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
        // �������� ������� ������� ����� � ������� �����������
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ��������� ������ �������� �� ������������ ��'���� �� �������
        Vector3 direction = mousePosition - parentTransform.position;

        // ���������� ��� �� ��������� �� �������� ������ (1, 0)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��������� ����������� ��'��� �� ��������� ���
        parentTransform.rotation = Quaternion.Slerp(parentTransform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.fixedDeltaTime);
    }
}
