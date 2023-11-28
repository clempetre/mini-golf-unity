using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Arrivee : MonoBehaviour
{
    public string Niveau;
    public Text messageText;
    public AudioClip arriveSound;
    private AudioSource audioSource;

    public Timer timerScript; // Référence au script du timer

    private void Start()
    {
        messageText.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();

        if (arriveSound != null)
        {
            audioSource.clip = arriveSound;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            messageText.gameObject.SetActive(true);

            if (arriveSound != null)
            {
                audioSource.Play();
            }

            timerScript.StopTimer(); // Appel de la fonction pour arrêter le timer

            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    public float Delai;

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(Delai);

        SceneManager.LoadScene(Niveau);
    }
}
