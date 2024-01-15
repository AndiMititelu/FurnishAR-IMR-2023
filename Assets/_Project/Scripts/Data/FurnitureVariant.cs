using System;
using UnityEngine;

[Serializable]
public class FurnitureVariant
{
    [field: SerializeField] public FurnitureMaterial Material { get; private set; }
    [field: SerializeField] public Sprite Preview { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
}
