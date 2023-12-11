using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField] private Transform pointAwake;
    [SerializeField, Range(10, 100)] private int Resolution = 10;

    private Transform[] points;
    void Awake() {
        float step = 2f / Resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[Resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointAwake);
            points[i] = point;
            position.x = (i + 0.5f) *step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}
