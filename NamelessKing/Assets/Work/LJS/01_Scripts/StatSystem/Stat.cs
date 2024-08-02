using System;
using System.Collections.Generic;
using UnityEngine;

namespace LJS
{
    [Serializable]
    public class Stat
    {
        [SerializeField] private float _baseValue;

        public List<float> modifiers;
        public bool isPercent;

        public float GetValue()
        {
            float final = _baseValue;
            foreach (float value in modifiers)
            {
                final += value;
            }

            return final;
        }

        public void AddModifier(float value)
        {
            if (value != 0)
                modifiers.Add(value);
        }

        public void RemoveModifier(float value)
        {
            if (value != 0)
                modifiers.Remove(value);
        }

        public void SetDefalutValue(float value)
        {
            _baseValue = value;
        }
    }
}

