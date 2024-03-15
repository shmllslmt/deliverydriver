using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float timeDelay = 0.5f;
    [SerializeField] Color32 hasParcel = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noParcel = new Color32(1, 1, 1, 1);
    SpriteRenderer carRenderer;

    void Start()
    {
        carRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Ouch! I hit something X|");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup" && !hasPackage)
        {
            Debug.Log("Item is picked up.");

            hasPackage = true;

            Destroy(collision.gameObject, timeDelay);

            carRenderer.color = hasParcel;
        }
        else if (collision.tag == "Dropoff" && hasPackage)
        {
            Debug.Log("Item is delivered.");

            hasPackage = false;

            carRenderer.color = noParcel;
        }
    }
}
