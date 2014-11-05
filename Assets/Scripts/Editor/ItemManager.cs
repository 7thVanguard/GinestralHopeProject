using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class ItemManager : EditorWindow
{
    bool showingWeapons = false;
    bool showingArmors = false;
    bool showingConsumables = false;
    bool showingComponents = false;


    // Creates the new Window
    [MenuItem("Ginestral Hope/Item Database")]
	static void Init () 
    {
        ItemManager window = (ItemManager)EditorWindow.CreateInstance(typeof(ItemManager));
        window.Show();
	}
    

    void OnGUI()
    {
        ItemDictionary itemsList = GameObject.Find("World").GetComponent<ItemDictionary>();

        List<Weapon> WeaponsList = new List<Weapon>();
        List<Armor> ArmorsList = new List<Armor>();
        List<Consumable> ConsumablesList = new List<Consumable>();
        List<GameComponent> ComponentsList = new List<GameComponent>();

        foreach (Item item in itemsList.ItemsList)
        {
            if (item.GetType() == typeof(Weapon))
                WeaponsList.Add((Weapon)item);
            else if (item.GetType() == typeof(Armor))
                ArmorsList.Add((Armor)item);
            else if (item.GetType() == typeof(Consumable))
                ConsumablesList.Add((Consumable)item);
            else if (item.GetType() == typeof(GameComponent))
                ComponentsList.Add((GameComponent)item);
        }

        // Write labels in the inspector
        EditorGUILayout.BeginHorizontal();

        //+ Weapons
        
        EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel = 0;
        showingWeapons = EditorGUILayout.Foldout(showingWeapons, "Weapons");
        if (showingWeapons)
        {
            // Display the weapons in the database
            foreach (Weapon weapon in WeaponsList)
            {
                EditorGUI.indentLevel = 2;

                // Set in horizontal the title name and the erase button
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(weapon.name);
                if (GUILayout.Button("Erase weapon"))
                    itemsList.ItemsList.Remove(weapon);
                EditorGUILayout.EndHorizontal();
                
                // Set the atributes
                EditorGUI.indentLevel = 3;
                weapon.name = EditorGUILayout.TextField("Name: ", weapon.name);
                weapon.description = EditorGUILayout.TextField("Description: ", weapon.description);
                weapon.cost = int.Parse(EditorGUILayout.TextField("Cost: ", weapon.cost.ToString()));
                weapon.damage = int.Parse(EditorGUILayout.TextField("Base Damage: ", weapon.damage.ToString()));
                EditorGUILayout.Space();
            }

            // Adding an item to the list
            if (GUILayout.Button("Add new weapon"))
            {
                Weapon newWeapon = (Weapon)ScriptableObject.CreateInstance<Weapon>();

                newWeapon.name = "New weapon";
                newWeapon.description = "";
                newWeapon.cost = 0;
                newWeapon.damage = 0;

                itemsList.ItemsList.Add(newWeapon);
            }
        }
        EditorGUILayout.EndVertical();

        //+ Armors

        EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel = 0;
        showingArmors = EditorGUILayout.Foldout(showingArmors, "Armors");
        if (showingArmors)
        {
            // Display the weapons in the database
            foreach (Armor armor in ArmorsList)
            {
                EditorGUI.indentLevel = 2;

                // Set in horizontal the title name and the erase button
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(armor.name);
                if (GUILayout.Button("Erase armor"))
                    itemsList.ItemsList.Remove(armor);
                EditorGUILayout.EndHorizontal();

                // Set the atributes
                EditorGUI.indentLevel = 3;
                armor.name = EditorGUILayout.TextField("Name: ", armor.name);
                armor.description = EditorGUILayout.TextField("Description: ", armor.description);
                armor.cost = int.Parse(EditorGUILayout.TextField("Cost: ", armor.cost.ToString()));
                armor.protection = int.Parse(EditorGUILayout.TextField("Protection: ", armor.protection.ToString()));
                EditorGUILayout.Space();
            }

            // Adding an item to the list
            if (GUILayout.Button("Add new armor"))
            {
                Armor newArmor = (Armor)ScriptableObject.CreateInstance<Armor>();

                newArmor.name = "New armor";
                newArmor.description = "";
                newArmor.cost = 0;
                newArmor.protection = 0;

                itemsList.ItemsList.Add(newArmor);
            }
        }
        EditorGUILayout.EndVertical();

        //+ Consumables

        EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel = 0;
        showingConsumables = EditorGUILayout.Foldout(showingConsumables, "Consumables");
        if (showingConsumables)
        {
            // Display the consumables in the database
            foreach (Consumable consumable in ConsumablesList)
            {
                EditorGUI.indentLevel = 2;

                // Set in horizontal the title name and the erase button
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(consumable.name);
                if (GUILayout.Button("Erase consumable"))
                    itemsList.ItemsList.Remove(consumable);
                EditorGUILayout.EndHorizontal();

                // Set the atributes
                EditorGUI.indentLevel = 3;
                consumable.name = EditorGUILayout.TextField("Name: ", consumable.name);
                consumable.description = EditorGUILayout.TextField("Description: ", consumable.description);
                consumable.cost = int.Parse(EditorGUILayout.TextField("Cost: ", consumable.cost.ToString()));
                consumable.health = int.Parse(EditorGUILayout.TextField("Health recover: ", consumable.health.ToString()));
                EditorGUILayout.Space();
            }

            // Adding an item to the list
            if (GUILayout.Button("Add new consumable"))
            {
                Consumable newComsumable = (Consumable)ScriptableObject.CreateInstance<Consumable>();

                newComsumable.name = "New consumable";
                newComsumable.description = "";
                newComsumable.cost = 0;
                newComsumable.health = 0;

                itemsList.ItemsList.Add(newComsumable);
            }
        }
        EditorGUILayout.EndVertical();

        //+ Components

        EditorGUILayout.BeginVertical();
        EditorGUI.indentLevel = 0;
        showingComponents = EditorGUILayout.Foldout(showingComponents, "Components");
        if (showingComponents)
        {
            // Display the weapons in the database
            foreach (GameComponent component in ComponentsList)
            {
                EditorGUI.indentLevel = 2;

                // Set in horizontal the title name and the erase button
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(component.name);
                if (GUILayout.Button("Erase component"))
                    itemsList.ItemsList.Remove(component);
                EditorGUILayout.EndHorizontal();

                // Set the atributes
                EditorGUI.indentLevel = 3;
                component.name = EditorGUILayout.TextField("Name: ", component.name);
                component.description = EditorGUILayout.TextField("Description: ", component.description);
                component.cost = int.Parse(EditorGUILayout.TextField("Cost: ", component.cost.ToString()));
                EditorGUILayout.Space();
            }

            // Adding an item to the list
            if (GUILayout.Button("Add new component"))
            {
                GameComponent newComponent = (GameComponent)ScriptableObject.CreateInstance<GameComponent>();

                newComponent.name = "New component";
                newComponent.description = "";
                newComponent.cost = 0;

                itemsList.ItemsList.Add(newComponent);
            }
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
    }
}
