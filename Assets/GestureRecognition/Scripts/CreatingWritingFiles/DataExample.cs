using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataExample
{
    public string gestureName;
    public List<Vector3> gestureData;
    public string speechData;
 //   public string timestamp;
    public string timeSinceStart;
    public string state;

    public double[] GetAsArray()
    {
        List<double> tmpLine = new List<double>();
        foreach (Vector3 currentPoint in gestureData)
        {
            tmpLine.Add(currentPoint.x);
            tmpLine.Add(currentPoint.y);
            tmpLine.Add(currentPoint.z);
        }
        return tmpLine.ToArray();
    }
}