using System;
using UnityEngine;

[Serializable]
public class FurnitureMaterial
{
    [field: SerializeField] public Sprite Preview { get; private set; }
    [field: SerializeField] public Material Material { get; private set; }
}