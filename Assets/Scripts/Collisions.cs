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
        //Αποτέλεσμα σύγκρουσης με τα εμπόδια της κάθε πίστας (-1 ζωή)
        if (collisionInfo.collider.tag == "Obstacles") {
            if(lives > 0){
                lives -=1;
                HealthUpdate.text = "Lives: " + lives.ToString();
                source.PlayOneShot(clip2, 1f);
            }
            //0 ζωές (Game Over)
            if(lives <= 0){
                EndGame();
            }
        }             
    }
    private void OnTriggerExit (Collider other)
    {
        // Αποτέλεσμα σύγκρουσης με το Power Up (+1 ζωή)
        if (other.gameObject.tag == "Lives"){
            lives +=1;
            HealthUpdate.text = "Lives: " + lives.ToString();
            source.PlayOneShot(clip3, 1f);
        }
        // Αποτέλεσμα πτώσης από τα όρια της πίστας (Game Over)
        if (other.gameObject.name == "PlatformLimits"){
            EndGame();
        }
    }
    // συνάρτσηση διαχείρισης GAME OVER
    //(σταματάει η κίνηση, ενεργοποιείται το GameOver TMPro, σταματάει κάθε άλλος ήχος, παίζει το clip1, ξεκινάει το παιχνίδι απ την αρχή)
    private void EndGame(){ 
        movement.enabled = false; 
        GameOver.enabled = true;
        source.Stop();
        source.PlayOneShot(clip1, 1f);
        Invoke("LoadMainScene", time); 
    }
    // συνάρτηση επαναφόρτωσης σκηνής (αρχή game)
    private void LoadMainScene(){
        SceneManager.LoadScene("MainScene"); 
        }
}
