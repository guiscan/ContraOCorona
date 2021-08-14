using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
    Hand theHand;
    public GameObject invenciblePanel;
    public GameObject invencibleCounter;
    Text invencibleText;

    // Start is called before the first frame update
    void Start()
    {
        invencibleText = invencibleCounter.GetComponent<Text>();
        theHand = FindObjectOfType<Hand>();

    }

    // Update is called once per frame
    void Update()
    {
        // invenciblePanel.SetActive(true);
        
        if (theHand.isGel) {
            invenciblePanel.SetActive(true);
            invencibleCounter.SetActive(true);
            invencibleText.text = theHand.invencibleTimer.ToString("00");
        } else {
            invenciblePanel.SetActive(false);
            invencibleCounter.SetActive(false);
        }
    }

}
