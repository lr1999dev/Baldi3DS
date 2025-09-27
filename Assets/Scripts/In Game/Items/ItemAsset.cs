using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Asset", menuName = "Custom Assets/Item Asset")]
public class ItemAsset : ScriptableObject 
{
    public ItemBase item;
    public Sprite sprite;
    public string displayName;

    public LayerMask acceptLayers;
}