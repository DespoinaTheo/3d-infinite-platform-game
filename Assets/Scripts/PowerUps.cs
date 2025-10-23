using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject LivesPrefab;
       void Start()
    {
        // δημιουργία των Power Ups Objects
        SpawnLives();
    }

    // συνάρτηση δημιουργίας των 3 objects τυπου Power Ups
     void SpawnLives()
    {
        Vector3 spawnPosition1 = new Vector3(5, 1.4f, -600);
        Instantiate(LivesPrefab, spawnPosition1, Quaternion.identity);
        Vector3 spawnPosition2 = new Vector3(-4, 1.4f, 580);
        Instantiate(LivesPrefab, spawnPosition2, Quaternion.identity);
        Vector3 spawnPosition3 = new Vector3(2, 1.4f, 680);
        Instantiate(LivesPrefab, spawnPosition3, Quaternion.identity);
    }
}