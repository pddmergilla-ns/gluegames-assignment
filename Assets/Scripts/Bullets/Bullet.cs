using UnityEngine;

// in case we decided to expand to have different bullet types
public abstract class Bullet : MonoBehaviour, ISpawn
{
    public abstract void Move();
    public abstract void Initialize(Vector2 attackDirection, ObjectPool objectPool, EffectManager effectManager);
    public string Tag {get;set;}
}




