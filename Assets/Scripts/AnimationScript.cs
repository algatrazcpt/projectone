using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Transform targetPostion;

    public Camera mainCam;
    public Camera coridorCam;
    public Camera cryCam;
    public Camera hapyCam;
    public float showTime = 4f;
    Vector3 startPosition;
    public static AnimationScript instance;
    bool cameraActive = false;
    public bool cameraStats = false;
    void Start()
    {
        startPosition = transform.position;
        instance = this;
    }
    public void MovePlayer()
    {
        StartCoroutine(PlayerMove());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator PlayerMove()
    {
        while (Vector3.Distance(transform.position, targetPostion.position) > 0.2f)
        {
            Vector3 direction = targetPostion.position - transform.position;
            transform.position += direction.normalized * Time.deltaTime * 2f;
            yield return new WaitForEndOfFrame();

        }
        Debug.Log("target arrived");
        transform.position = startPosition;
        CameraActiveted();
        yield return null;
    }
    void CameraReturn()
    {
        mainCam.enabled = true;
        coridorCam.enabled = false;
        cryCam.enabled = false;
        hapyCam.enabled = false;
        GameManagerControl.Instance.CompleteLevel();
    }
    public void CameraChange(bool value)
    {
        cameraActive = value;
        coridorCam.enabled = true;
    }
    void CameraActiveted()
    {
        if (cameraActive)
        {
            hapyCam.enabled = true;
            coridorCam.enabled = false;
        }
        else
        {
            coridorCam.enabled = false;
            cryCam.enabled = true;
        }
        Invoke("CameraReturn", showTime);
    }
}
