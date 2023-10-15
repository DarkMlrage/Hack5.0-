using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float minDelay = 1f;
    [SerializeField]
    private float maxDelay = 3f;
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private int maxHP = 100;  // ����������� �� ������
    [SerializeField]
    private int damage = 10;  // �����, ���� ����� �������� ������
    [SerializeField]
    private float delayBetweenDamage = 0.5f;

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private Vector3 startTargetPosition;

    private bool inFirstStage = true;
    public int currentHP;  // ������� �� ������

    private bool isDamageCoroutineRunning = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("������� �� ��������� � ����� 'Player'. ��������� ���������� ��� ��� �������������, �� ��'��� ������ �������� �� ����.");
        }
        else
        {
            currentHP = maxHP;  // ���������� ������� ��

            // �������� � ������� ����
            StartCoroutine(FirstStage());
        }
    }

    private IEnumerator FirstStage()
    {
        inFirstStage = true;

        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);

        Vector3 playerPosition = player.transform.position;
        Vector3 startPosition = transform.position;

        startTargetPosition = playerPosition - transform.position;

        StartCoroutine(SecondStage());
    }

    private IEnumerator SecondStage()
    {
        inFirstStage = false;

        if (player != null)
        {
            while (Vector2.Distance(transform.position, startTargetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, startTargetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
        }

        StartCoroutine(FirstStage());
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - 90);
        }
    }
    
    public void TakeDamage(int damageAmount)
    {
        if (!isDamageCoroutineRunning)
        {
            StartCoroutine(DealDamageWithDelay(damageAmount));
        }
    }

    private IEnumerator DealDamageWithDelay(int damageAmount)
    {
        isDamageCoroutineRunning = true;
        StartCoroutine(Damage());
        Damage(); // ���������� Damage() ��� ���� ������� ��� ������� ��������� ���.        
        yield return new WaitForSeconds(delayBetweenDamage); // �������� ����� ���������� ������.
        currentHP -= damageAmount; 
        isDamageCoroutineRunning = false;
    }

    // ����� ��� ������� ����� ������
    public void Die()
    {
        KillCount.Instance.IncrementKillCount();
        Destroy(gameObject);
    }

    // �����, ���� ����������� ��� ������� � ������ ��'������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ����������, �� ��'��� �� ��� "Player" � �������� ������ �����
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private IEnumerator Damage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }
}
