using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScore : MonoBehaviour
{
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText.text = "Gems Collected: " + PlayerController.count.ToString();
    }
}
