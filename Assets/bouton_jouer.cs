using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bouton_jouer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public string Niveau; // Le nom de la scène à charger

    public void StartLevel()
    {
            // Chargez la scène spécifiée.
            SceneManager.LoadScene(Niveau);
    }
}
