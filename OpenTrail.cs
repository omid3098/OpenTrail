using System.Collections.Generic;
using OpenTouch;
using UnityEngine;
public class OpenTrail : MonoBehaviour
{
    [SerializeField] TrailPrefab[] trailParticlePrefabs;
    private List<TrailPrefab> trailObjects = new List<TrailPrefab>();
    private Camera _camera;

    private void Start()
    {
        foreach (var trailPrefab in trailParticlePrefabs)
        {
            var trailObject = Instantiate(trailPrefab);
            trailObject.transform.SetParent(transform, false);
            trailObject.DisableTrail();
            trailObjects.Add(trailObject);
        }
        _camera = TouchManager.touchCamera;
    }
    private void OnEnable()
    {
        TouchManager.OnFingerSet += onFingerSet;
        TouchManager.OnFingerDown += onFingerDown;
        TouchManager.OnFingerUp += onFingerUp;
    }

    private void OnDisable()
    {
        TouchManager.OnFingerSet -= onFingerSet;
        TouchManager.OnFingerDown -= onFingerDown;
        TouchManager.OnFingerUp -= onFingerUp;
    }

    private void onFingerDown(Finger finger)
    {
        Debug.Log("FingerDown");
        foreach (var trail in trailObjects) trail.DisableTrail();
        Vector3 touchPos = _camera.ScreenToWorldPoint(finger.position);
        touchPos = new Vector3(touchPos.x, touchPos.y, 0);
        transform.position = touchPos;
        foreach (var trail in trailObjects) trail.EnableTrail();
    }

    private void onFingerSet(Finger finger)
    {
        Vector3 touchPos = _camera.ScreenToWorldPoint(finger.position);
        touchPos = new Vector3(touchPos.x, touchPos.y, 0);
        transform.position = touchPos;
        // if (!tailObject.activeInHierarchy) tailObject.SetActive(true);
    }

    private void onFingerUp(Finger finger)
    {
        foreach (var trailGo in trailObjects) trailGo.DisableTrail();
    }
}