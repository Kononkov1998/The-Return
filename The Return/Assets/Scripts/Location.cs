using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [TextArea]
    public string description;
    public Connection[] connections;
    public List<Item> items = new List<Item>();

    public string GetConnectionsText()
    {
        string result = string.Empty;

        foreach (Connection connection in connections)
        {
            if (connection.isEnabled)
            {
                result += connection.description + "\n";
            }
        }

        return result;
    }

    public string GetItemsText()
    {
        if (items.Count == 0)
        {
            return string.Empty;
        }

        string result = "You see ";
        bool first = true;
        foreach (Item item in items)
        {
            if (item.isEnabled)
            {
                if (!first)
                {
                    result += " and ";
                }
                result += item.description;
                first = false;
            }
        }
        result += "\n";
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.isEnabled)
            {
                return true;
            }
        }
        return false;
    }

    public Connection GetConnection(string connectionName)
    {
        foreach (Connection connection in connections)
        {
            if (connection.name.ToLower() == connectionName.ToLower())
            {
                return connection;
            }
        }
        return null;
    }
}
