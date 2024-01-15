using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArObject", menuName = "ScriptableObjects/ArObject")]
public class ArObject : ScriptableObject
{
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public FurnitureType Type { get; private set; }
    [field: SerializeField] public List<FurnitureVariant> Variants { get; private set; }

    private static List<ArObject> arObjects;

    public static void Init()
    {
        arObjects = Resources.LoadAll<ArObject>("ArObjects/").ToList();
    }

    public static List<ArObject> Get(FurnitureType _type)
    {
        if (_type==FurnitureType.All)
        {
            return arObjects;
        }
        return arObjects.Where(_arObject => _arObject.Type == _type).ToList();
    }
    
    public static ArObject Get(int _id)
    {
        return arObjects.Find(_element => _element.Id == _id);
    }

    public static List<ArObject> Get()
    {
        return arObjects;
    }
}
