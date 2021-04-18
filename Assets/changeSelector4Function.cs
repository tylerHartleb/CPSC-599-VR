using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeSelector4Function : MonoBehaviour
{
    
    public Color32 changedColor;
    public Button button;
    public Image image;

    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeColor()
    {
        image.color = changedColor;
    }
}
