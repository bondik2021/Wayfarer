using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Test : Port
{
    public Test(Orientation portOrientation, Direction portDirection, Capacity portCapacity, Type type) : base(portOrientation, portDirection, portCapacity, type)
    {
    }

    public Test(Port port) : base(port.orientation, port.direction, port.capacity, port.portType)
    {
    }

    public override void OnStopEdgeDragging()
    {
        Debug.Log(portName);
    }

}
