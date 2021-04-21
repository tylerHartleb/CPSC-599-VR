using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARTrackedImageManager))]
public class ObjectTrackedCamManager : MonoBehaviour
{

    [SerializeField]
    [Tooltip("The camera to set on the world space UI canvas for each instantiated image info.")]
    Camera m_WorldSpaceCanvasCamera;

    /// <summary>
    /// The prefab has a world space UI canvas,
    /// which requires a camera to function properly.
    /// </summary>
    public Camera worldSpaceCanvasCamera
    {
        get { return m_WorldSpaceCanvasCamera; }
        set { m_WorldSpaceCanvasCamera = value; }
    }

    ARTrackedObjectManager m_TrackedObjectManager;
    PageSwiper swiper_script;

    void Awake()
    {
        m_TrackedObjectManager = GetComponent<ARTrackedObjectManager>();
    }

    void OnEnable()
    {
        m_TrackedObjectManager.trackedObjectsChanged += OnTrackedObjectChanged;
    }

    void OnDisable()
    {
        m_TrackedObjectManager.trackedObjectsChanged -= OnTrackedObjectChanged;
    }

    void UpdateInfo(ARTrackedObject trackedObject)
    {
        // Set canvas camera
        var canvas = trackedObject.GetComponentInChildren<Canvas>();
        canvas.worldCamera = worldSpaceCanvasCamera;
        //Find the GameObject
        GameObject obj = GameObject.Find("swiper");

        //Get script attached to it
        swiper_script = obj.GetComponent<PageSwiper>();
        //float scale = trackedObject.size.x;

        //Call the function
        //swiper_script.UpdatePos(scale);
    }

    void OnTrackedObjectChanged(ARTrackedObjectsChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            //trackedImage.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
            UpdateInfo(trackedImage);
        }
        foreach (var trackedImage in eventArgs.updated)
            UpdateInfo(trackedImage);
    }



}
