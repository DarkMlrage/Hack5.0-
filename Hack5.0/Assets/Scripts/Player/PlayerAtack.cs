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

    [SerializeField] SoundSwitcher soundSwitcher;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {            
            mainAtack.DealAtack();
        }
        else
        {            
        }
    }
}
