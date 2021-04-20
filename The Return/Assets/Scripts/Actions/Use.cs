using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (UseItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        if (UseItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = $"There is no {noun}";
    }

    private bool UseItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (item.isEnabled)
                {
                    if (controller.player.CanUseItem(item) && item.InteractWith(controller, "Use"))
                    {
                        return true;
                    }
                    controller.currentText.text = $"The {item.itemName} does nothing";
                    return true;
                }
            }
        }
        return false;
    }
}
