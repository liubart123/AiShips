using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mechanic.Main
{
    public class RayOfMovement : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }
}