using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public static Action<GameObject, Vector3> OnObjectDragged;

    public Vector3 StartPosition;
    private void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            // Update the position of the dragged object based on the mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        // Set the flag to indicate that the object is being dragged
        isDragging = true;

        // Calculate the offset between the object's position and the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
    }

    void OnMouseUp()
    {
        // Reset the flag when the mouse is released
        isDragging = false;

        OnObjectDragged?.Invoke(gameObject, transform.position);

    }
}
