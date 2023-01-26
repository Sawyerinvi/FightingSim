using System;
using System.Collections.Generic;
using UnityEngine;
using FightingSim.Assets.Scripts.Weapons;
using System.Linq;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FightingSim.Assets.Scripts.Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "Fight Sim/Config/Weapon Data")]
    public class WeaponData : ScriptableObject, IWeaponConfig
    {

        public GameObject Prefab => WeaponPrefab;
        public Transform WeaponTransform { get; set; }
        public string WeaponName => _name;
        public GameObject WeaponPrefab;
        public string _name = "New Weapon";
        public int TypeIndex;
        public List<WeaponDamageType> List = new List<WeaponDamageType>();



        [Serializable]
        public class WeaponDamageType
        {
            public DamageType Type;
            public float Amount;
        }

        public Damage GetWeaponBaseDamage()
        {
            var dmg = new Damage();
            foreach (var type in List)
            {
                dmg.AddDamage(type.Type, type.Amount);
            }
            return dmg;
        }


    }


    [CustomEditor(typeof(WeaponData))]
    public class WeaponCustomEditor : Editor
    {
        WeaponData script;
        private void OnEnable()
        {
            script = (WeaponData)target;
        }

        public override void OnInspectorGUI()
        {
            EditorUtility.SetDirty(script);
            script._name = EditorGUILayout.TextField(script._name);
            if (CheckForChanges())
            {
                script.List = ListSetup();
            }
            for (int i = 0; i < script.List.Count; i++)
            {

                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(script.List[i].Type.ToString());
                script.List[i].Amount = EditorGUILayout.FloatField(script.List[i].Amount, GUILayout.Width(75f));
                EditorGUILayout.EndHorizontal();
            }
            script.WeaponPrefab = (GameObject)EditorGUILayout.ObjectField("Weapon Collider:", script.WeaponPrefab, typeof(GameObject), false);
        }

        private bool CheckForChanges()
        {
            var types = (DamageType[])Enum.GetValues(typeof(DamageType));
            if (script.List.Count != types.Length) return true;
            for (int i = 0; i < types.Length; i++)
            {
                if (script.List.ElementAtOrDefault(i) == null ||
                    script.List[i].Type != types[i])
                {
                    return true;
                }
            }

            return false;
        }

        private List<WeaponData.WeaponDamageType> ListSetup()
        {
            var types = (DamageType[])Enum.GetValues(typeof(DamageType));
            List<WeaponData.WeaponDamageType> newList = new List<WeaponData.WeaponDamageType>();
            for (int i = 0; i < types.Length; i++)
            {
                var type = new WeaponData.WeaponDamageType();
                type.Type = types[i];
                newList.Add(type);
            }
            for (int i = 0; i < newList.Count; i++)
            {
                for (int x = 0; x < script.List.Count; x++)
                {
                    if (newList[i].Type == script.List[x].Type)
                    {
                        newList[i].Amount = script.List[x].Amount;
                    }
                }
            }
            return newList;
        }



    }
}


