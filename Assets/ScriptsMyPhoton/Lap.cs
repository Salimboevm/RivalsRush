using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviourPun
{
    private short laps=3;
    private short currentLap = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lap"))
        {
            if (base.photonView.IsMine)
            {
                currentLap++;
                print(currentLap);

                GameUI.Instance.LapText(currentLap);
                if (currentLap >= laps)
                {
                    GameUI.Instance.Win();
                }
            }
        }
    }
}
