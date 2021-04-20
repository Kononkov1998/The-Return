using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        if (ReadItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = $"There is no {noun}";
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (item.isEnabled && item.playerCanRead)
                {
                    if (controller.player.CanReadItem(item) && item.InteractWith(controller, "Read"))
                    {
                        return true;
                    }
                    controller.currentText.text = $"There is nothing written on {item.itemName}";
                    return true;
                }
            }
        }
        return false;
    }
}
