using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public Willow_Movement movement;
    public int lives = 3;
    public TMPro.TMP_Text HealthUpdate;
    public TMPro.TMP_Text GameOver;
    [SerializeField] private float time  = 5f;
    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    void Start()
    {
        GameOver.enabled = false;
    }
    void OnCollisionEnter (Collision collisionInfo)
    {
        // Collision result with level obstacles (-1 life)
        if (collisionInfo.collider.tag == "Obstacles") {
            if(lives > 0){
                lives -=1;
                HealthUpdate.text = "Lives: " + lives.ToString();
                source.PlayOneShot(clip2, 1f);
            }
            // 0 lives (Game Over)
            if(lives <= 0){
                EndGame();
            }
        }             
    }
    private void OnTriggerExit (Collider other)
    {
        // Collision result with Power Up (+1 life)
        if (other.gameObject.tag == "Lives"){
            lives +=1;
            HealthUpdate.text = "Lives: " + lives.ToString();
            source.PlayOneShot(clip3, 1f);
        }
        // Result of falling outside the level boundaries (Game Over)
        if (other.gameObject.name == "PlatformLimits"){
            EndGame();
        }
    }
    // GAME OVER management function
    // (stops movement, enables GameOver TMPro, stops all other audio, plays clip1, restarts the game)
    private void EndGame(){ 
        movement.enabled = false; 
        GameOver.enabled = true;
        source.Stop();
        source.PlayOneShot(clip1, 1f);
        Invoke("LoadMainScene", time); 
    }
    // Function to reload the scene (restart game)
    private void LoadMainScene(){
        SceneManager.LoadScene("MainScene"); 
        }
}
