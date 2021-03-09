using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour
{
    /// <summary>
    /// Draws a ray with a dot at the end of the ray.
    /// </summary>
    /// <param name="_pos"></param>
    /// <param name="_dir"></param>
    /// <param name="_color"></param>
    public static void DrawRay(Vector3 _pos, Vector3 _dir, Color _color)
    {
#if UNITY_EDITOR
        if (_dir.sqrMagnitude > 0.01f)
        {
            Debug.DrawRay(_pos, _dir, _color);
            UnityEditor.Handles.color = _color;
            UnityEditor.Handles.DrawSolidDisc(_pos + _dir, Vector3.up, 0.25f);
        }
#endif
    }

    /// <summary>
    /// Draws the name ontop of the position.
    /// </summary>
    /// <param name="_pos"></param>
    /// <param name="_lable"></param>
    /// <param name="_color"></param>
    public static void DrawLable(Vector3 _pos, string _lable, Color _color)
    {
#if UNITY_EDITOR
        if (_lable.Length > 0)
        {
            UnityEditor.Handles.BeginGUI();
            UnityEditor.Handles.color = _color;
            UnityEditor.Handles.Label(_pos, _lable);
            UnityEditor.Handles.EndGUI();
        }
#endif
    }

    /// <summary>
    /// Draws a disc at the position.
    /// </summary>
    /// <param name="_pos"></param>
    /// <param name="_radius"></param>
    /// <param name="_color"></param>
    public static void DrawDisc(Vector3 _pos, float _radius, Color _color)
    {
#if UNITY_EDITOR
        if (_radius > 0.01f)
        {
            UnityEditor.Handles.color = _color;
            UnityEditor.Handles.DrawSolidDisc(_pos, Vector3.up, _radius);
        }
#endif
    }

    /// <summary>
    /// Draws a disc at the position.
    /// </summary>
    /// <param name="_pos"></param>
    /// <param name="_radius"></param>
    /// <param name="_color"></param>
    public static void DrawCircle(Vector3 _pos, float _radius, Color _color)
    {
#if UNITY_EDITOR
        if (_radius > 0.01f)
        {
            UnityEditor.Handles.color = _color;
            UnityEditor.Handles.DrawWireDisc(_pos, Vector3.up, _radius);
        }
#endif
    }
}
