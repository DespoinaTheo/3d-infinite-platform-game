using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMPro.TMP_Text StoryLine1;
    public TMPro.TMP_Text StoryLine2;
    public TMPro.TMP_Text StoryLine3;
    public TMPro.TMP_Text StoryLine4;
    public TMPro.TMP_Text Directions;   
    public TMPro.TMP_Text StartGame; 
    //μετράει πόσες φορές πατήθηκε το "right"
    private int cnt = 0;

    void Start(){
        // αρχικοποιώ όλα τα text ως απενεργοποιημένα
        StartGame.enabled = true;
        StoryLine1.enabled = false;
        StoryLine2.enabled = false;
        StoryLine3.enabled = false;
        StoryLine4.enabled = false;
        Directions.enabled = false;
        
    }
    void Update()
    {
        // με το δεξί βέλος, ο παίκτης ενεργοποιεί διαδοχικά τα text του storyline
        if (Input.GetKeyDown("right")){
            cnt +=1;
        }
        if (cnt == 1){
            DeactivateText(StartGame);
            StoryLine1.enabled = true;
        }
        else if (cnt == 2){
            DeactivateText(StoryLine1);
            StoryLine2.enabled = true;
        }
        else if (cnt == 3){
            DeactivateText(StoryLine2);
            StoryLine3.enabled = true;
        }
        else if(cnt == 4){
            DeactivateText(StoryLine3);
            StoryLine4.enabled = true;
        }
        else if (cnt == 5){
            DeactivateText(StoryLine4);
            Directions.enabled = true;
        }
        
        if (Input.GetKeyDown("space"))
        {
            // Φορτώνει τη βασική σκηνή
            SceneManager.LoadScene("MainScene");
        }
    
}
    //συνάρτηση απενεργοποίησης των texts
    void DeactivateText(TMPro.TMP_Text text)
    {
        text.enabled = false;
    }
   
}