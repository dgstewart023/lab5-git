using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollisionHandler : MonoBehaviour
{
    public AudioSource carSound; // Assign this in the Inspector
    public string nextSceneName; // Set this in the Inspector

    private bool soundPlayed = false; // Ensure sound only plays once

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("WarningZone") && !soundPlayed) 
            {
                // Play the warning sound when entering WarningZone
                soundPlayed = true;
                if (carSound != null)
                {
                    carSound.Play();
                }
            }
            else if (gameObject.CompareTag("TransitionZone"))
            {
                // Load next scene when entering TransitionZone
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
