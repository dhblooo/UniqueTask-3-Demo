﻿using UnityEngine;
using System.Collections;

public class InteractionPickUp : InteractionBase
{
    public string thing_name;

    protected override bool InteractionDemand()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    protected override void Interaction()
    {
        character_interaction.PickUpThing(thing_name);
    }
}
