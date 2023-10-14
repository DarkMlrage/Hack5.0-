using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public PlayerInput control;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        control = new PlayerInput();
    }

    private void OnEnable()
    {
        // ���������� InputActionMap
        control.Main.Enable();
        control.UI.Enable();
    }

    private void OnDisable()
    {
        // ��������� InputActionMap
        control.Main.Disable();
        control.UI.Disable();
    }



}
