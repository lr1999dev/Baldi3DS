using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemAcceptor
{
    bool ItemFits(string itemName);
    void InsertItem(string itemName);
}