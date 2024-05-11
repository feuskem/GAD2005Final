using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Initial scale of the object
    private Vector3 initialScale;

    // How much the object shrinks when clicked
    public float shrinkScale = 0.9f;

    // The object to spawn
    public GameObject objectToSpawn;

    // The spawn location object
    public GameObject spawnLocation;

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

                // Check if a spawn location is assigned
                if (spawnLocation != null)
                {
                    // Spawn a new object at the position of the spawn location
                    Instantiate(objectToSpawn, spawnLocation.transform.position, Quaternion.identity);
                }
                else
                {
                    Debug.LogWarning("Spawn location is not assigned.");
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Restore the object to its initial scale when the mouse button is released
            transform.localScale = initialScale;
        }
    }
}
