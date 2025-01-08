using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
     int _maximumHealth = 100; 
      
     int _currentHealth = 0;

    override public string ToString()
    { 
         return _currentHealth + " / " + _maximumHealth; 
    }

    public bool IsDead { get { return _currentHealth <= 0; } }

    Renderer _renderer;

    PlayerStats _playerStats;

    [SerializeField] 
    AudioClip[] _hitSounds;

    [SerializeField] 
    AudioClip _deathSound;

    [SerializeField] 
    AudioClip _healSound;

    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _currentHealth = _maximumHealth;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerStats = player.GetComponent<PlayerStats>();
    }

    public void Heal(int healAmount)
    { 
         _currentHealth += healAmount; 
 
        if (_currentHealth > _maximumHealth) 
        { 
            _currentHealth = _maximumHealth; 
        }

        if (_healSound != null)
        {
         GetComponent<AudioSource>().clip = _healSound;
         GetComponent<AudioSource>().Play();
        }

    } 

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        else
        {
         if (_hitSounds != null && _hitSounds.Length > 0)
         {
           AudioClip soundToUse = _hitSounds[Random.Range(0, _hitSounds.Length)];
           GetComponent<AudioSource>().clip = soundToUse;
           GetComponent<AudioSource>().Play();
         }
        }

        if (_currentHealth == 0)
     {
            if (_deathSound != null)
                {
                 GetComponent<AudioSource>().clip = _deathSound;
                 GetComponent<AudioSource>().Play();
                }

            if (tag == "Player") 
            {
                Animator b = GetComponentInChildren<Animator>();
                Destroy(GetComponent<PlayerMovement>());
                Destroy(GetComponent<PlayerAnimation>());
                Destroy(GetComponent<RifleWeapon>());

                Destroy(b);
            }
            else 
            {
                Animation a = GetComponentInChildren<Animation>();
                 a.Stop();
                _playerStats.ZombiesKilled++;
                EnemySpawnManager.OnEnemyDeath();
                Destroy(GetComponent<EnemyMovement>());
                Destroy(GetComponentInChildren<EnemyAttack>());
                EnemyDrops d = GetComponent<EnemyDrops>();
                d.OnDeath();
                Destroy(gameObject, 8.0f);

            }

            Destroy(GetComponent<CharacterController>());

            Ragdoll r = GetComponent<Ragdoll>();
            if (r != null)
             {
              r.OnDeath();
             }
        }

    }

// Update is called once per frame
void Update()
    {
        if (IsDead && !_renderer.isVisible)
        {
           Destroy(gameObject);
        }
     }
}
