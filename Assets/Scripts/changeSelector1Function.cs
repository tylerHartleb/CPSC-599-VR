using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeSelector1Function : MonoBehaviour
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

// blue     : #FFFFFF
// green    : #384C28
// black    : #383838
// red      : #E35959
