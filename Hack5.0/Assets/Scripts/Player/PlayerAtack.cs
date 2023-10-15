using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] Atack mainAtack;
    [SerializeField] Atack atack1;
    [SerializeField] Atack atack2;
    [SerializeField] Atack atack3;

    public AudioManager audioManager; // Посилання на AudioManager


    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            audioManager.PlaySound3Once();
            mainAtack.DealAtack();
            audioManager.PlaySound4Looped();
        }
        else
        {
            audioManager.StopSound4Looped();
        }
    }
}
