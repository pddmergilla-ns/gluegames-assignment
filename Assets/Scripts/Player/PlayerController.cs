using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private ObjectPool bulletPool;

    [SerializeField] private float shootingCooldown = 0.5f;
    [SerializeField] private Bullet bulletUsed;
    [SerializeField] private EffectManager effectManager;

    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick attackJoystick;

    private Vector2 moveInput;
    private Vector2 attackInput;
    private float shootingCooldownTime;

    void Start()
    {
        ResetShootingCooldown();
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    public void PlayerDiedEffect()
    {
        effectManager.PlayPlayerDeathEffect(transform.position);
    }

    private void HandleMovement()
    {
        moveInput = new Vector2(movementJoystick.InputDirection.x, movementJoystick.InputDirection.y);
        transform.Translate(moveInput.normalized * moveSpeed * Time.deltaTime);
    }

    private void HandleAttack()
    {
        attackInput = new Vector2(attackJoystick.InputDirection.x, attackJoystick.InputDirection.y);
        shootingCooldownTime -= Time.deltaTime;

        if (attackInput != Vector2.zero && shootingCooldownTime <= 0)
        {
            Shoot();
            ResetShootingCooldown();
        }
    }

    private void Shoot()
    {
        var bullet = bulletPool.GetObject(bulletUsed.Tag);
        bullet.transform.position = firePoint.position;
        bullet.GetComponent<Bullet>().Initialize(attackInput.normalized, bulletPool, effectManager);
    }

    private void ResetShootingCooldown()
    {
        shootingCooldownTime = shootingCooldown;
    }
}
