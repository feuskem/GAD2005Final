using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUnit : MonoBehaviour
{
    public Animator anim;
    public bool isitcastle;
    public GameObject RestardB;

    // Combat settings
    public float attackDamage = 10f;
    public float attackRate = 1f;
    public string enemyTag = "Enemy";
    public string enemyTag2 = "Enemy";

    // Health settings
    public float maxHealth = 100f;
    public Slider healthBar;

    // Private variables
    private float currentHealth;
    private float nextAttackTime = 0f;
    private List<GameObject> enemiesInRange = new List<GameObject>();

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        UpdateHealthBar();

    }

    void Update()
    {
        // Check if the unit is stopped and attack enemies in range
        if (enemiesInRange.Count > 0)
        {
            AttackInRangeEnemies();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            enemiesInRange.Add(other.gameObject);
        }
       else if (other.CompareTag(enemyTag2))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            enemiesInRange.Remove(other.gameObject);
        }
        else if (other.CompareTag(enemyTag2))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void AttackInRangeEnemies()
    {
        if (Time.time >= nextAttackTime)
        {
            foreach (var enemy in enemiesInRange)
            {
                if (enemy != null) // Check if enemy is still valid
                {
                    Attack(enemy);
                }
            }
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack(GameObject enemy)
    {
        CombatUnit enemyHealth = enemy.GetComponent<CombatUnit>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(attackDamage);
            if(isitcastle==false)
            {
                anim.SetTrigger("Attack");
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        // Handle death (e.g., play animation, remove from scene)
        if (isitcastle == false)
        {
            anim.SetBool("Death", true);
        }
        if (isitcastle == true)
        {
            RestardB.SetActive(true);
            Time.timeScale = 0;
        }

        Destroy(gameObject);
        
    }

}

