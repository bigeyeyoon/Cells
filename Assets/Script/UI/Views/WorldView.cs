using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldView : View
{
    private static WorldView m_instance;
    public static WorldView GetInstance() { if (m_instance == null) m_instance = new WorldView(); return m_instance; }

    public override void Initialize()
    {
        m_instance = this;
        viewType = CanvasType.WORLD;

    }
}
