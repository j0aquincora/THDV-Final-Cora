using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bomberman : MonoBehaviour
{
    public GameObject bomba;
    public int bombAmmo;
    public Transform playerPos;
    public TMP_Text bombAmmoText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBombAmmoUI();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bomb"))
        {
            bombAmmo++;
            Destroy(collision.gameObject);
            UpdateBombAmmoUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&bombAmmo>=1)
        {
            PlaceBomb();
        }

    }
    void PlaceBomb()
    {
        bombAmmo--;
        Instantiate(bomba,playerPos.position,playerPos.rotation);
        UpdateBombAmmoUI();
    }
    void UpdateBombAmmoUI()
    {
        bombAmmoText.text = "Bombas: " + bombAmmo.ToString(); // Actualiza el texto con el valor de bombAmmo
    }
}
