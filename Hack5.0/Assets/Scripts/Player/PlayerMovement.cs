using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody2D rb;
    private bool isLeftMouseButtonPressed = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 moveInput = InputManager.Instance.control.Main.Move.ReadValue<Vector2>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Перевірка стану лівої кнопки мишки
        if (Input.GetMouseButton(0))
        {
            isLeftMouseButtonPressed = true;
        }
        else
        {
            isLeftMouseButtonPressed = false;
        }

        Movement(moveInput, mousePosition);
    }

    void Movement(Vector2 input, Vector3 mousePosition)
    {

        if (isLeftMouseButtonPressed && mousePosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (isLeftMouseButtonPressed && mousePosition.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }

        if (input.x != 0 || input.y != 0)
        {
            playerAnimator.isMoving(true);
            rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);

            if (!isLeftMouseButtonPressed)
            {
                if (input.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (input.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
        else
        {
            playerAnimator.isMoving(false);
        }
    }
}
