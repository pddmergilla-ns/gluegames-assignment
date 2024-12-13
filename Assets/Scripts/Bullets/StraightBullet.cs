using UnityEngine;
public class StraightBullet : Bullet
{
    [SerializeField] private readonly float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private string nameTag;
    private Vector2 direction;
    private ObjectPool pool;
    private EffectManager effectManager;
    private const float halflife = 1f;
    private float duration;
    public override void Initialize(Vector2 attackDirection, ObjectPool objectPool, EffectManager effectManager)
    {
        Tag = nameTag;
        direction = attackDirection;
        pool = objectPool;
        this.effectManager = effectManager;
        duration = halflife;
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            effectManager.PlayAttackHitEffect(transform.position);
            enemy.TakeDamage(damage);
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        pool.ReturnObject(Tag, gameObject);
    }
}