using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField] private Transform pointAwake;
    [SerializeField, Range(10, 100)] private int Resolution = 10;
    [SerializeField] FunctionLib.FunctionName function;

    private Transform[] points;
    void Awake() {
        float step = 2f / Resolution;
        var scale = Vector3.one * step;
        points = new Transform[Resolution * Resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointAwake);
            points[i] = point;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }
    void Update() {
        FunctionLib.Function f = FunctionLib.GetFunction(function);
        float time = Time.time;
        float step = 2f / Resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++) {
            if (x == Resolution) {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = f(u, v, time);
        }
    }
}
