using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class ItemSO : ScriptableObject
    {

        public string Name { get; set; }

        [field: SerializeField]
        [field: TextArea]

        public string Description { get; set; }

        [field: SerializeField]
        public Sprite ItemImage { get; set; }

        [field: SerializeField]
        public int Cost;



    }
}

