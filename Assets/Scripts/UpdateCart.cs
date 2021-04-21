using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementCart()
    {
        CartTracker.cartAmount += 1;
    }

    public void DecrementCart()
    {
        if (CartTracker.cartAmount > 0)
        {
            CartTracker.cartAmount -= 1;
        }
    }

    public void ResetCart()
    {
        CartTracker.cartAmount = 0;
    }
}
