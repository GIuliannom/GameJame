using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAgression : MonoBehaviour
{
    EnemyMovement enemyMovement;
    PlayerHealth playerHealth;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    public float agressionBar;

    void Awake()
    {
        enemyMovement = enemy.GetComponent<EnemyMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();

        if (SceneManager.GetActiveScene().name == "Level01")
        {
           agressionBar = 30f;
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            agressionBar = 25f;
        }

        if (SceneManager.GetActiveScene().name == "Level03")
        {
            agressionBar = 20f;
        }

        if (SceneManager.GetActiveScene().name == "Level04")
        {
            agressionBar = 15f;
        }

        if (SceneManager.GetActiveScene().name == "Level05")
        {
            agressionBar = 10f;
        }

    }

    void Update()
    {
        if (agressionBar > 0)
        {
            // Lógica a ser executada enquanto agressionBar for maior que zero
            // Pode incluir balão de fala aleatório (entre 4 opções), por exemplo
        }
    }

    public void TakeDamage(float damage)
    {
        agressionBar -= damage;
        if (agressionBar <= 0)
        {
            // balao de fala putasso
            float enemyDamage = SceneManager.GetActiveScene().buildIndex + 5;
            Destroy(gameObject);
        }
    }
}
