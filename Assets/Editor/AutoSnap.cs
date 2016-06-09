using UnityEngine;
using UnityEditor;

public class AutoSnap : EditorWindow
{
    private Vector3 prevPosition;
    private Vector3 prevRotation;
    private bool doSnap = true;
    private bool doRotateSnap = true;
    private float snapValue = 1;
    private float snapRotateValue = 1;

    [MenuItem("Edit/Auto Snap %_l")]

    static void Init()
    {
        var window = (AutoSnap)EditorWindow.GetWindow(typeof(AutoSnap));
        window.maxSize = new Vector2(200, 100);
    }

    public void OnGUI()
    {
        doSnap = EditorGUILayout.Toggle("Auto Snap", doSnap);
        doRotateSnap = EditorGUILayout.Toggle("Auto Snap Rotation", doRotateSnap);
        snapValue = EditorGUILayout.FloatField("Snap Value", snapValue);
        snapRotateValue = EditorGUILayout.FloatField("Rotation Snap Value", snapRotateValue);
    }

    public void Update()
    {
        if (doSnap
            && !EditorApplication.isPlaying
            && Selection.transforms.Length > 0
            && Selection.transforms[0].position != prevPosition)
        {
            Snap();
            prevPosition = Selection.transforms[0].position;
        }

        if (doRotateSnap
            && !EditorApplication.isPlaying
            && Selection.transforms.Length > 0
            && Selection.transforms[0].eulerAngles != prevRotation)
        {
            RotateSnap();
            prevRotation = Selection.transforms[0].eulerAngles;
            //Debug.Log("Value of rotation " + Selection.transforms[0].rotation);
            //Debug.Log ("Value of old Rotation " + prevRotation);
        }
    }

    private void Snap()
    {
        foreach (var transform in Selection.transforms)
        {
            RectTransform rectTrans = transform.transform as RectTransform;
            if (rectTrans)
            {
                var pos = rectTrans.anchoredPosition;
                pos.x = Round(pos.x);
                pos.y = Round(pos.y);
                rectTrans.anchoredPosition = pos;
                var size = rectTrans.sizeDelta;
                size.x = Round(size.x);
                size.y = Round(size.y);
                rectTrans.sizeDelta = size;
            }
            else
            {
                var t = transform.transform.position;
                t.x = Round(t.x);
                t.y = Round(t.y);
                t.z = Round(t.z);
                transform.transform.position = t;
            }
        }
    }

    private void RotateSnap()
    {
        foreach (var transform in Selection.transforms)
        {
            var r = transform.transform.eulerAngles;
            r.x = RotRound(r.x);
            r.y = RotRound(r.y);
            r.z = RotRound(r.z);
            transform.transform.eulerAngles = r;
        }
    }

    private float Round(float input)
    {
        return snapValue * Mathf.Round((input / snapValue));
    }

    private float RotRound(float input)
    {
        Debug.Log("The division is: " + (input / snapRotateValue));
        Debug.Log("The rounding is: " + Mathf.Round((input / snapRotateValue)));
        Debug.Log("The return is: " + (snapRotateValue * Mathf.Round((input / snapRotateValue))));
        return snapRotateValue * Mathf.Round((input / snapRotateValue));
    }

    public void OnEnable() { EditorApplication.update += Update; }
}