using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public GameObject day;
    public GameObject night;
    // Start is called before the first frame update
    void Start()
    {
        var rnd =  Random.Range(0f,1f);

        if (rnd<0.5f)
        {
            day.SetActive(true);
        }
        else
        {
            night.SetActive(true);
        }
    }

    
}
