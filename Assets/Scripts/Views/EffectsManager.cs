using UnityEngine;

public class EffectManager : MonoBehaviour
{

    [Header("Effects")]
    [SerializeField] private ParticleSystem enemyDeathEffect;
    [SerializeField] private ParticleSystem attackHitEffect;
    [SerializeField] private ParticleSystem playerDamageEffect;
    [SerializeField] private ParticleSystem playerDeathEffect;


    public void PlayEnemyDeathEffect(Vector3 position)
    {
        PlayEffect(enemyDeathEffect, position);
    }

    public void PlayAttackHitEffect(Vector3 position)
    {
        PlayEffect(attackHitEffect, position);
    }

    public void PlayPlayerDamageEffect(Vector3 position)
    {
        PlayEffect(playerDamageEffect, position);
    }

    public void PlayPlayerDeathEffect(Vector3 position)
    {
        PlayEffect(playerDeathEffect, position);
    }

    private void PlayEffect(ParticleSystem effect, Vector3 position)
    {
        if (effect != null)
        {
            ParticleSystem instantiatedEffect = Instantiate(effect, position, Quaternion.identity);
            instantiatedEffect.Play();
            Destroy(instantiatedEffect.gameObject, instantiatedEffect.main.duration);
        }
    }
}
