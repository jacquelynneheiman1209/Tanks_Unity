using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject parent;
    public Canvas canvas;
    public Camera mainCamera;

    public UIHealthBar healthBar;
    public UIShieldBar shieldBar;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();

        healthBar = GetComponentInChildren<UIHealthBar>();
        shieldBar = GetComponentInChildren<UIShieldBar>();

        mainCamera = Camera.main;

        healthBar.manager = this;
        shieldBar.manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas != null && mainCamera != null)
        {
            canvas.transform.LookAt(mainCamera.transform.position);
        }
    }
}
