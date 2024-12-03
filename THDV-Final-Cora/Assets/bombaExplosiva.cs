using System.Collections;

using UnityEngine;

public class BombaExplosiva : MonoBehaviour
{
    public float bombDelay = 2f;  // Tiempo de retardo antes de explotar
    public float explosionRadius = 5f; // Radio de la explosi�n

    // Este script espera que la bomba tenga un Collider con Is Trigger activado.
    private void Start()
    {
        // Inicia la corutina que maneja la explosi�n despu�s de un retardo.
        StartCoroutine(Explosion());
    }

    // Coroutine para esperar antes de la explosi�n
    private IEnumerator Explosion()
    {
        // Espera el tiempo de retardo antes de explotar
        yield return new WaitForSeconds(bombDelay);

        // Explosi�n (destruir paredes cercanas)
        Explode();
    }

    // L�gica de la explosi�n
    void Explode()
    {
        // Usa OverlapSphere para detectar los objetos dentro del radio de la explosi�n
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Wall"))  // Solo destruye las paredes
            {
                Destroy(hitCollider.gameObject); // Destruye las paredes cercanas
                Debug.Log("Pared destruida por la explosi�n!");
            }
        }

        // Destruye la propia bomba
        Destroy(gameObject);
        Debug.Log("La bomba ha explotado.");
    }
}
