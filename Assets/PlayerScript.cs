using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 30f;
    public int nb_count = 0;
    private bool isSpacePressed = false;
    private float accumulatedForce = 2f;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        // Accumuler la force lorsque la barre d'espace est enfoncée
        if (Input.GetButton("Jump"))
        {
            isSpacePressed = true;
            accumulatedForce += m_Thrust * Time.fixedDeltaTime;
        }
        else if (isSpacePressed) // Appliquer la force quand la barre d'espace est relâchée
        {
            m_Rigidbody.AddForce(transform.forward * accumulatedForce, ForceMode.Impulse);
            accumulatedForce = 2f; // Réinitialiser la force accumulée
            isSpacePressed = false;
            nbCount();
        }

        // Utiliser Input.GetAxis pour déplacer le joueur en fonction des axes verticaux et horizontaux
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Translatez le joueur en fonction des axes
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * 1f * Time.fixedDeltaTime);
    }


    void nbCount(){
        nb_count ++;
        Debug.Log(nb_count);
    }

} 