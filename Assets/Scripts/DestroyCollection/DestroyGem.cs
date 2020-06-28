using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGem : DestroyCollection
{
    protected override void Start()
    {
        base.Start();
        item = "gem";
    }
}
