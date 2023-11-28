using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioSource audioSource; // Faites glisser votre AudioSource ici
    public AudioClip pauseMusic;

    // Ajoutez cette ligne pour référencer votre musique de fond
    public AudioSource backgroundMusic;

    private bool isPaused = false; 

    void Start()
    {
        Time.timeScale = 1f;

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }

        // Assurez-vous que backgroundMusic est assigné dans l'inspecteur ou à partir du code
        if (backgroundMusic == null)
        {
            Debug.LogError("Background Music AudioSource is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;

            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
            }

            // Démarrer la musique de pause
            if (audioSource != null && pauseMusic != null)
            {
                audioSource.clip = pauseMusic;
                audioSource.Play();
            }

            // Mettre en pause la musique de fond
            if (backgroundMusic != null)
            {
                backgroundMusic.Pause();
            }
        }
        else
        {
            Time.timeScale = 1f;

            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }

            // Arrêter la musique de pause
            if (audioSource != null)
            {
                audioSource.Stop();
            }

            // Reprendre la musique de fond
            if (backgroundMusic != null)
            {
                backgroundMusic.UnPause();
            }
        }
    }
}
