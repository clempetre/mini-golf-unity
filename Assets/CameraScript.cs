using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void RestartTheGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Ca marche");

}
}
