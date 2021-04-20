using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string description;
    public bool playerCanTake;
    public bool isEnabled = true;
    public Interaction[] interactions;
    public Item targetItem = null;
    public bool playerCanTalkTo = false;
    public bool playerCanRead = false;

    public bool InteractWith(GameController controller, string actionKeyword, string noun = "")
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyword)
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                {
                    continue;
                }

                foreach (Item itemToDisable in interaction.itemsToDisable)
                {
                    itemToDisable.isEnabled = false;
                }
                foreach (Item itemToEnable in interaction.itemsToEnable)
                {
                    itemToEnable.isEnabled = true;
                }
                foreach (Connection connectionToDisable in interaction.connectionsToDisable)
                {
                    connectionToDisable.isEnabled = false;
                }
                foreach (Connection connectionToEnable in interaction.connectionsToEnable)
                {
                    connectionToEnable.isEnabled = true;
                }

                if (interaction.teleportLocation != null)
                {
                    controller.player.Teleport(interaction.teleportLocation);
                }

                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);

                return true;
            }
        }
        return false;
    }
}
