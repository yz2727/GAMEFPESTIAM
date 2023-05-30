using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public int gunDamage = 20;

    private bool hitTrigger = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && collision.collider.isTrigger)
        {
            // Cible avec le "Trigger" activé, détruire immédiatement la balle
            Destroy(gameObject);
            return;
        }

        // Vérifier si la collision concerne un ennemi
        ReceiveDamage enemy = collision.gameObject.GetComponent<ReceiveDamage>();
        if (enemy != null)
        {
            // Infliger des dégâts à l'ennemi
            enemy.TakeDamage(gunDamage);
            Debug.Log("Balle a touché l'ennemi. Dégâts infligés : " + gunDamage);
        }
        else
        {
            Debug.Log("Balle a touché un objet sans composant ReceiveDamage.");
        }

        // Détruire la balle après 4 secondes si elle n'a pas touché une cible avec le "Trigger" activé
        if (!hitTrigger)
        {
            Destroy(gameObject, 4f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            hitTrigger = true;
        }
    }
}
