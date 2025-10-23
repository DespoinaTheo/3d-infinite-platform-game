using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // κοινές μεταβλητές για όλα τα εμπόδια
    float spawnInterval = 0.2f;   
    float spawnRangeX = 6f;
    private Quaternion rotation;

    // μεταβλητές θέσης για τα εμπόδια τύπου sickness
    public GameObject SicknessPrefab;    
    float currentZsick = -1705f;
    float ZSickIncrement = 15f;

    // μεταβλητές θέσης για τα εμπόδια τύπου fires
    public GameObject FirePrefab;  
    float currentZfire = -495f;
    float ZFireIncrement = 10f;

    //μεταβλητές θέσης και περιστροφής για τα εμπόδια τύπου trunks
    public GameObject TrunkPrefab;  
    float currentZtrunk = -1642f;
    float ZTrunkIncrement = 180f;
    private Vector3 TrunkRotation = new Vector3(0f, 0f, 90f);


    //μεταβλητές θέσης και περιστροφής για τα εμπόδια τύπου axes
    public GameObject AxePrefab; 
    private Vector3 axeRotation1;
    private Vector3 axeRotation2;
    float currentZ3a = 720f; 
    float Z3a_Increment = 15f;     
    float currentZ3b = 715f;  
    float Z3b_Increment = 25f;
    

   
    void Start()
    {
        //Ξεκινάει την επανάληψη της δημιουργίας των όλων των εμποδίων
        InvokeRepeating("SpawnSickness", 0f, spawnInterval);
        InvokeRepeating("SpawnFire", 0f, spawnInterval);
        InvokeRepeating("SpawnTrunk", 0f, spawnInterval);
        InvokeRepeating("SpawnAxe", 0f, spawnInterval);
    }
    // Συνάρτηση για την δημιουργία των sickness
    void SpawnSickness()
    {
        float Xsick = Random.Range(-spawnRangeX, spawnRangeX);
        float Zsick = currentZsick;
        
        if (Zsick < -705){
            Vector3 spawnPosition = new Vector3(Xsick, 0.54f, Zsick);
            Instantiate(SicknessPrefab, spawnPosition, Quaternion.identity);
        }

        currentZsick += ZSickIncrement;
    }

    // Συνάρτηση για την δημιουργία των fires
    void SpawnFire()
    {
        float Xfire = Random.Range(-spawnRangeX, spawnRangeX);
        float Zfire = currentZfire;

        if (Zfire < 505){
            Vector3 spawnPosition = new Vector3(Xfire, 0.6f, Zfire);
            Instantiate(FirePrefab, spawnPosition, Quaternion.identity);
        }
        
        currentZfire += ZFireIncrement;
    }

    // Συνάρτηση για την δημιουργία των trunks
    void SpawnTrunk()
    {
        float ZTrunk = currentZtrunk;

        if (ZTrunk < -705 || (-452 < ZTrunk && ZTrunk < 505)){
            Vector3 spawnPosition = new Vector3(0f, 0.6f, ZTrunk);
            rotation =Quaternion.Euler(TrunkRotation);
            Instantiate(TrunkPrefab, spawnPosition, rotation);
        }
        
        currentZtrunk += ZTrunkIncrement;
    }
    // Συνάρτηση για την δημιουργία των axes
    void SpawnAxe()
    {
        float X_axe1 = Random.Range(3.5f, 5.5f);
        float X_axe2 = Random.Range(-5.5f, -3.5f);
        float Z3a = currentZ3a;
        float Z3b = currentZ3b;
        float rotationZa = Random.Range(50, 90);
        float rotationZb = Random.Range(50, 90);

        axeRotation1 = new Vector3(-17.5f, 4.5f, rotationZa);
        axeRotation2 = new Vector3(-17.5f, 175f, rotationZb);

    if (Z3a < 1715f){
            Vector3 spawnPosition = new Vector3(3.5f, 1.5f, Z3a);
            rotation =Quaternion.Euler(axeRotation1);
            Instantiate(AxePrefab, spawnPosition, rotation);
        }
    if (Z3b < 1715f){
            Vector3 spawnPosition = new Vector3(-3.5f, 1.5f, Z3b);
            rotation =Quaternion.Euler(axeRotation2);
            Instantiate(AxePrefab, spawnPosition, rotation);
        }
        currentZ3a += Z3a_Increment;
        currentZ3b += Z3b_Increment;
    }
}