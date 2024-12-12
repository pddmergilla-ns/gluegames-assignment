using UnityEngine;
// just a sample here for other type of bullet
public class WavyBullet : Bullet
{
    public override void Initialize(Vector2 attackDirection, ObjectPool objectPool, EffectManager effectManager)
    {
        
    }
    public override void Move() 
    {
        // wavy motion logic
    }
}