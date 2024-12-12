using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class LogManager
{
    public static MethodInfo clearMethodInfo;
    public static void ClearLog()
    {
        if (clearMethodInfo == null)
        {
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            clearMethodInfo = type.GetMethod("Clear");
        }
        clearMethodInfo.Invoke(new object(), null);
    }
}
