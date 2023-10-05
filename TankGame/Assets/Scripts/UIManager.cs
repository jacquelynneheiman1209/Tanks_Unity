using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Canvas canvas;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();

        mainCamera = Camera.main;
        canvas.worldCamera = mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.LookAt(mainCamera.transform.position);
    }

    public void SetCanvasRenderModer(RenderMode mode)
    {
        canvas.renderMode = mode;
    }
}
