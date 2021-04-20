using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private string connectionName;
    public string description;
    public Location location;
    public bool isEnabled;

    private void Start()
    {
        connectionName = gameObject.name;
    }
}
