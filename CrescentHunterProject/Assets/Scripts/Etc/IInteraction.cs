using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{
    string IName { get; }
    void OnInteraction();
    bool IsActive();
}
