using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;
    public List<Item> inventory = new List<Item>();

    void Start()
    {

    }

    void Update()
    {

    }

    public bool ChangeLocation(string connectionName)
    {
        Connection connection = currentLocation.GetConnection(connectionName);

        if (connection != null && connection.isEnabled)
        {
            currentLocation = connection.location;
            return true;
        }

        return false;
    }

    public void Teleport(Location destination)
    {
        currentLocation = destination;
    }

    internal bool CanUseItem(Item item)
    {
        if (item.targetItem == null)
        {
            return true;
        }

        if (HasItem(item.targetItem) || currentLocation.HasItem(item.targetItem))
        {
            return true;
        }

        return false;
    }

    internal bool CanReadItem(Item item)
    {
        if (item.targetItem == null)
        {
            return true;
        }

        if (HasItem(item.targetItem) || currentLocation.HasItem(item.targetItem))
        {
            return true;
        }

        return false;
    }

    internal bool CanTalkToItem(Item item)
    {
        return item.playerCanTalkTo;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            if (item == itemToCheck && item.isEnabled)
            {
                return true;
            }
        }
        return false;
    }
}
