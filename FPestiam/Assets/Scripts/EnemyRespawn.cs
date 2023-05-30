using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnDelay = 3f;

    private bool isDead = false;
    private GameObject currentEnemy;

    private void Update()
    {
        if (isDead)
        {
            // Attendre le délai de respawn
            respawnDelay -= Time.deltaTime;
            if (respawnDelay <= 0f)
            {
                // Réapparition de l'ennemi
                RespawnEnemy();
            }
        }
    }

    public void Die()
    {
        // L'ennemi est mort, activer le délai de respawn
        isDead = true;
        respawnDelay = 3f;
    }

    private void RespawnEnemy()
    {
        // Détruire l'ennemi existant s'il y en a un
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
        }

        // Créer un nouvel ennemi à la position du respawn
        currentEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        
        // Réinitialiser les paramètres de l'ennemi si nécessaire (par exemple, remettre ses points de vie au maximum)
        // currentEnemy.GetComponent<EnemyHealth>().ResetHealth();
        
        // Réinitialiser les autres composants ou états de l'ennemi si nécessaire
        
        // Désactiver le délai de respawn
        isDead = false;
    }

    public void StartRespawnTimer()
    {
        respawnDelay = 3f;
        isDead = true;
        Debug.Log("Respawn timer started.");
    }
}
