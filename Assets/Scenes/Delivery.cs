using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay;
    [SerializeField] Color pickupColor;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D delivery)
    {
        Debug.Log("Bummmm!!!!!");
    }

    void OnTriggerEnter2D(Collider2D delivery)
    {
        if (delivery.tag == "SpeedUp")
        {
            Debug.Log("Speedddd!");
        }

        if (delivery.tag == "Package" && hasPackage == false)
        {
            hasPackage = true;
            Debug.Log("Package is picked up");

            if (spriteRenderer != null)
            {
                spriteRenderer.color = pickupColor;
            }

            Destroy(delivery.gameObject, destroyDelay);
        }

        if (delivery.tag == "Customer" && hasPackage == true)
        {
            hasPackage = false;
            Debug.Log("Package is delivered");

            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.white;
            }
        }
    }
}
