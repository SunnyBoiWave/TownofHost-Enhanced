using UnityEngine;
using System.Collections.Generic;
using TOHE.Roles.Core;

[CreateAssetMenu(fileName = "RoleDictionary", menuName = "Role Management/Role Dictionary")]
public class RoleDictionary : ScriptableObject
{
    // We'll use a Serializable dictionary to allow it to be editable in the Unity Editor.
    [SerializeField]
    private List<RoleEntry> roles = new List<RoleEntry>();

    [System.Serializable]
    public struct RoleEntry
    {
        public CustomRoles roleType;
        public RoleBase roleBase;
    }

    // Method to initialize or update roles from CustomRoleManager
    private void OnEnable()
    {
        foreach (var role in CustomRoleManager.RoleClass)
        {
            roles.Add(new RoleEntry { roleType = role.Key, roleBase = role.Value });
        }
    }

    // Method to add a role to the dictionary and update CustomRoleManager
    public void AddRole(CustomRoles roleType, RoleBase role)
    {
        roles.Add(new RoleEntry { roleType = roleType, roleBase = role });
        CustomRoleManager.RoleClass[roleType] = role;
    }

    // Method to get a role by CustomRoles enum
    public RoleBase GetRole(CustomRoles roleType)
    {
        foreach (var role in roles)
        {
            if (role.roleType == roleType)
            {
                return role.roleBase;
            }
        }
        throw new System.Exception("Role not found: " + roleType);
    }

    // Method to list all roles
    public void ListRoles()
    {
        Debug.Log("Listing all roles:");
        foreach (var role in roles)
        {
            Debug.Log($"Role Type: {role.roleType}, Class: {role.roleBase.GetType().Name}, Enabled: {role.roleBase.IsEnable}");
        }
    }
}