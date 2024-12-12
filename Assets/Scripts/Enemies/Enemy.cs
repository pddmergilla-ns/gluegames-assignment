using UnityEngine;
public abstract class Enemy : MonoBehaviour, ISpawn
{
    public abstract void TakeDamage(int amount);
    public abstract void Initialize(Transform playerTransform, ObjectPool objectPool, GameManager gameManager, EffectManager effectManager);
    public abstract void Move();
    public string Tag { get; set; }
}
