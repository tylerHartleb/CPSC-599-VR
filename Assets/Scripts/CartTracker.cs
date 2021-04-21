using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartTracker : MonoBehaviour
{

    Text text;
    public static int cartAmount;
    public Button decrement;
    public Button add;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        cartAmount = 0;
        decrement.enabled = false;
        add.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cartAmount == 0)
        {
            decrement.enabled = false;
            add.enabled = false;
        } else
        {
            decrement.enabled = true;
            add.enabled = true;
        }
        text.text = cartAmount.ToString();
    }
}
