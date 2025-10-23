using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    
    void Update()
    {
        // ορίζω η κάμερα να ακολουθεί τη θέση/κινήσεις του παίκτη
        transform.position = player.position + offset;
    }
}
