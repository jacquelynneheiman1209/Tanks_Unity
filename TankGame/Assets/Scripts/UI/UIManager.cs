using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject parent;
    private Canvas canvas;
    private Camera mainCamera;

    [SerializeField] private UIHealthBar healthBar;
    [SerializeField] private UIShieldBar shieldBar;

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
}
