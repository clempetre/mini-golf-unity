using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moulin_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotationSpeed = 30.0f; // Vitesse de rotation en degrés par seconde

    private void Update()
    {
        // Rotation de l'objet autour de son axe Y à la vitesse spécifiée
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
