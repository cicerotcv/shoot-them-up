using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthBar : MonoBehaviour
{
    private Vector3 initialScale;

    public void Start()
    {
        initialScale = transform.localScale;
    }

    public void UpdateHealthBar(float percent)
    {
        Vector3 currentScale = transform.localScale;
        Vector3 parentScale = transform.parent.transform.localScale;

        transform.localScale =
            new Vector3(initialScale.x * percent,
                initialScale.y,
                initialScale.z);
    }
}
