using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Level_In_Out : MonoBehaviour
{
    public Willow_Movement movement;
    // ορίζω τις μεταβλητες τυπου TMPro που θα χρειαστούν στο game
    public TMPro.TMP_Text txtLevel1;
    public TMPro.TMP_Text txtLevel2;
    public TMPro.TMP_Text txtLevel3;
    public TMPro.TMP_Text GameOver;
    public TMPro.TMP_Text Victory;
    // χρόνος εμφάνισης του κάθε text
    [SerializeField] private float time  = 10f;
    // χρόνος αναμονής μέχρι να αλλάξω σκηνή
    [SerializeField] private float time2  = 5f;
    public AudioSource source;

    public AudioClip clip4;
    void Start()
    {   // αρχικοποιώ όλα τα text ως απενεργοποιημένα
        txtLevel1.enabled = false;
        txtLevel2.enabled = false;
        txtLevel3.enabled = false;
        Victory.enabled = false;
    }
    void Update(){
        //επιστροφή στο Wallpapper (με χρήση space)

        if (Input.GetKeyDown("space"))
        {
            LoadWallpapper();
        }
    }
    
    private void OnTriggerExit (Collider collision)
    {   //ενεργοποίηση txtLevel1
        if(collision.gameObject.name == "Level1"){
            txtLevel1.enabled = true;
            Invoke("DeactivateText", time);
        }
        // ενεργοποίηση txtLevel2
        else if(collision.gameObject.name == "Level2"){
            txtLevel2.enabled = true;
            Invoke("DeactivateText", time);
        }
        // ενεργοποίηση txtLevel3
        else if(collision.gameObject.name == "Level3"){
            txtLevel3.enabled = true;
            Invoke("DeactivateText", time);
        }
        // ενεργοποίηση Victory
        //(σταματάει η κίνηση, ενεργοποιείται το Victory TMPro, σταματάει κάθε άλλος ήχος, παίζει το clip4, φορτώνει την σκηνή Wallpapper)
        else if(collision.gameObject.name == "Victory"){
            Victory.enabled = true;
            Invoke("DeactivateText", time);
            movement.enabled = false;
            source.Stop();
            source.PlayOneShot(clip4, 1f);
            Invoke("LoadWallpapper", time2);
        }
        // αν έχει ενεργοποιηθεί το GameOver(απο το το script Collisions) απενεργοποιώ όλα τα άλλα TMPro
        if(GameOver.enabled){
            DeactivateText();
        }
    }
    // συνάρτηση απενεργοποίησης των TMPro
    void DeactivateText()
    {
        txtLevel1.enabled = false;
        txtLevel2.enabled = false;
        txtLevel3.enabled = false;
        Victory.enabled = false;
    }
    // συνάρτηση για να μεταφερθώ στην 1η σκήνη(Wallpapper)
    private void LoadWallpapper(){
        SceneManager.LoadScene("Wallpapper"); 
        }
}
