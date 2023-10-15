using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
            GameReferenceManager.Instance.sunPowerControler.AddSunPower(5);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X");
            player.TakeDamage(1);
        }
    }
}
