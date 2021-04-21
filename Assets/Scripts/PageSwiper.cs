using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public Canvas mainCanvas;
    public GameObject parentElement;
    public GameObject thisEl;
    public float percentThreshold = 0.0005f;
    public float easing = 0.5f;
    public float width;
    public int totalPages;
    private int currentPage = 1;
    private float localScale_x;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
        RectTransform rt = mainCanvas.transform.GetComponent<RectTransform>();
        if (parentElement != null)
        {
            Debug.Log(parentElement.transform.localScale.x);
            localScale_x = parentElement.transform.localScale.x * rt.localScale.x;
        } else
        {
            localScale_x = rt.localScale.x;
        }
        width = rt.sizeDelta.x * localScale_x;
        //Debug.Log(width);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePos(float scale)
    {
        RectTransform rt = mainCanvas.transform.GetComponent<RectTransform>();
        //localScale_x = localScale_x / scale;
        width = rt.sizeDelta.x * localScale_x;
    }

    public void OnDrag(PointerEventData data)
    {
        RectTransform rt = mainCanvas.transform.GetComponent<RectTransform>();
        float difference = (data.pressPosition.x * localScale_x) - (data.position.x * localScale_x) * 1.25f;
        //Debug.Log(difference);
        thisEl.transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = ((data.pressPosition.x * localScale_x) - (data.position.x * localScale_x) / width) * 100;
        //Debug.Log(percentage);
        if(Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-width, 0, 0);
            } else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(width, 0, 0);
            } 
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
            //Debug.Log(panelLocation);
        } else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
            //transform.position = panelLocation;
            //Debug.Log(panelLocation);
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            thisEl.transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
