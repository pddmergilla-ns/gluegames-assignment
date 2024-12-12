using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private ObjectPool bulletPool;

    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick attackJoystick;

    [SerializeField] private float shootingCooldown = 0.5f; 
    [SerializeField] private Bullet bulletUsed;
    [SerializeField] private EffectManager effectManager;

    
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

    public void PlayerDiedEffect () 
    {
        effectManager.PlayPlayerDeathEffect(transform.position);
    }

    private void HandleMovement()
    {

        moveInput = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical);
        transform.Translate(moveInput.normalized * moveSpeed * Time.deltaTime);
    }

    private void HandleAttack()
    {
        attackInput = new Vector2(attackJoystick.Horizontal, attackJoystick.Vertical);
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