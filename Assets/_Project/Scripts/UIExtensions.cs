using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
 
public static class UISetExtensions
{
    static MethodInfo toggleSetMethod;
 
    static UISetExtensions()
    {
        MethodInfo[] methods = typeof(Toggle).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        for (var i = 0; i < methods.Length; i++)
        {
            if (methods[i].Name == "Set" && methods[i].GetParameters().Length == 2)
            {
                toggleSetMethod = methods[i];
                break;
            }
        }
    }
    public static void Set(this Toggle instance, bool value, bool sendCallback)
    {
        toggleSetMethod.Invoke(instance, new object[] {value, sendCallback});
    }
}
 
