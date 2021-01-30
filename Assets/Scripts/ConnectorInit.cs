using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorInit : MonoBehaviour
{
    public GameObject player;
    public GameObject map;

    void Awake()
    {
        Connector.map = map;
        Connector.player = player;
    }
}

public static class Connector
{
    public static GameObject player;
    public static GameObject map;
}
