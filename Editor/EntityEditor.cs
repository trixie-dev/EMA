using System;
using System.Reflection;
using UnityEditor;
using EMA;
using UnityEngine;


    [CustomEditor(typeof(EMA.Entity), true)]
    public class EntityEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.LabelField("Class parameters", EditorStyles.boldLabel);
            base.OnInspectorGUI();
            
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            Entity entity = (Entity)target;
            EditorGUILayout.LabelField("Entities parameters", EditorStyles.boldLabel);
            entity.EntityId = EditorGUILayout.IntField("EntityId:", entity.EntityId);
            EditorGUILayout.LabelField("IsInitialized:", entity.IsInitialized.ToString());
            
            
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            // Modules
            EditorGUILayout.LabelField("Modules", EditorStyles.boldLabel);
           
            if (entity.ModulesManager != null)
            {
                foreach (var module in entity.ModulesManager.Modules)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                    EditorGUILayout.LabelField("- " + module.GetType().Name, EditorStyles.boldLabel);
                    Type type = module.GetType();
                    FieldInfo[] fields = type.GetFields( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly |
                                                         BindingFlags.NonPublic);
                    foreach (var field in fields)
                    {
                        EditorGUILayout.LabelField(FormatFieldName(field.Name) + ": " + field.GetValue(module));
                    }
                    if(fields.Length == 0)
                        EditorGUILayout.LabelField("No parameters", EditorStyles.miniLabel);
                    EditorGUILayout.EndVertical();
                }
            }
            
            EditorGUILayout.EndVertical();
            
            
            
            
            if (GUILayout.Button("Initialize"))
            {
                entity.Initialize(entity.EntityId);
            }

            if (GUILayout.Button("Destroy"))
            {
                entity.SafeDestroy();
            }
            
            // Застосовуємо зміни
            if (GUI.changed)
            {
                EditorUtility.SetDirty(entity);
            }
        }
        
        private string FormatFieldName(string name)
        {
            // format <Horizontal>k_BackingField -> Horizontal
            if (name.Contains(">"))
            {
                name = name.Substring(1, name.IndexOf(">") - 1);
            }
            // format _horizontal -> Horizontal
            else if (name.Contains("_"))
            {
                name = name.Substring(1, name.Length - 1);
            }
            // format m_horizontal -> Horizontal
            else if (name.Contains("m_"))
            {
                name = name.Substring(2, name.Length - 2);
            }
            // horizontal -> Horizontal
            name = char.ToUpper(name[0]) + name.Substring(1);
            // HorizontalInput -> Horizontal Input
            name = System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2");
            return name;
            
        }
        
    }
