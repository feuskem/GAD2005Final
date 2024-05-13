using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Initial scale of the object
    private Vector3 initialScale;

    // How much the object shrinks when clicked
    public float shrinkScale = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial scale of the object
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has clicked on the object
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            // Check if the ray intersects with this object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // If the object is clicked, shrink it
                transform.localScale = initialScale * shrinkScale;

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Restore the object to its initial scale when the mouse button is released
            transform.localScale = initialScale;
        }
    }
}
