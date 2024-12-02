using System.Collections;

using UnityEngine;

public class BombaExplosiva : MonoBehaviour
{
    public float bombDelay = 2f;  
    public float explosionRadius = 5f;

    
    private void Start()
    {
       
        StartCoroutine(Explosion());
    }

    
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(bombDelay);

        Explode();
    }

    
    void Explode()
    {
       
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Wall"))  // Solo destruye las paredes
            {
                Destroy(hitCollider.gameObject); // Destruye las paredes cercanas
                Debug.Log("Pared destruida por la explosión!");
            }
        }

       
        Destroy(gameObject);
        Debug.Log("La bomba ha explotado.");
    }
}
