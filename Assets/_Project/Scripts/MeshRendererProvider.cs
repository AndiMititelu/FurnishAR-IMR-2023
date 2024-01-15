using System.Collections.Generic;
using UnityEngine;

public class MeshRendererProvider : MonoBehaviour
{
    [field: SerializeField] public List<MeshRenderer> MeshRenderers { get; private set; } = new ();
}
