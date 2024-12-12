using UnityEngine;

public class NormalEnemy : Enemy
{
    [SerializeField] private int health = 3;
    [SerializeField] private float speed = 3f;
    [SerializeField] private string _tag;
    private Transform player;
    private ObjectPool pool;

    private float damageCooldown = 1f;
    private float nextDamageTime;
    private int actualHealth;
    private int maxHealth => health;
    private GameManager gameManager;
    private EffectManager effectManager;

    public override void Initialize(Transform playerTransform, ObjectPool objectPool, GameManager gameManager, EffectManager effectManager)
    {
        player = playerTransform;
        pool = objectPool;
        actualHealth = maxHealth;
        Tag = _tag;
        this.gameManager = gameManager;
        this.effectManager = effectManager;
    }

    void Update()
    {
        Move();
    }

    public override void TakeDamage(int amount)
    {
        actualHealth -= amount;
        if (actualHealth <= 0)
        {
            effectManager.PlayEnemyDeathEffect(transform.position);
            
            pool.ReturnObject(Tag, gameObject);
            gameManager.EnemyKilled();
        }
    }

    public override void Move()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            effectManager.PlayPlayerDamageEffect(collision.transform.position);

            nextDamageTime = Time.time + damageCooldown;
            collision.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
