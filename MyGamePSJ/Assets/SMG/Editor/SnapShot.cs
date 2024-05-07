using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;


public class SnapShot : EditorWindow
{
    static SnapShot _win;
    static Camera _cam;

    [MenuItem("Dev/SMG/SnapShot")]
    static void Init()
    {
        if (_win == null)
        {
            //_win = EditorWindow.CreateWindow<SnapShot>(true);
            _win = EditorWindow.GetWindow<SnapShot>();
            Debug.Log("Create Window: SnapShot");
        }

        _win.Show();
        _win.Focus();
    }

    //private void CreateGUI()
    //{
    //    //rootVisualElement.AddToClassList("Camera");

    //}

    /*
     * ��� ī�޶� �ִ� Target Texture(Render Texture)��
     * PNG���Ϸ� �����ϴ� ���α׷�
     * 1. "Camera"�� ��� ī�޶� ����
     *  i) ��� ī�޶󿡴� Target Texture(Raw Image(Render Texture))�� �����ؾ� ��
     * 2. "Save Map texture as PNG" ��ư�� ���� ���� ����
     * 
     */
    void OnGUI()
    {

        _cam = EditorGUILayout.ObjectField("Camera", _cam, typeof(Camera), true, null) as Camera;
        if(_cam != null && _cam.targetTexture != null)
            EditorGUI.DrawPreviewTexture(new Rect(0, 20, 100, 100), _cam.targetTexture);

        if (GUILayout.Button("Save Map texture as PNG"))
        {
            if(_cam == null)
            {
                EditorUtility.DisplayDialog(
                    "Select Camara",
                    "You Must Select a Camera first!",
                    "Ok");
                return;
            }
            if (_cam.targetTexture == null)
            {
                EditorUtility.DisplayDialog(
                    "Set Camera Target Texture",
                    "You Must Setting Camera:Target Texture",
                    "Ok");
                return;
            }

            //if (texture == null)
            //{
            //    EditorUtility.DisplayDialog(
            //        "Select Texture",
            //        "You Must Select a Texture first!",
            //        "Ok");
            //    return;
            //}

            var path = EditorUtility.SaveFilePanel(
                "Save MAP texture as PNG",
                Application.dataPath,
                ".png",
                "png");

            if (path.Length != 0)
            {
                Debug.Log("Save File");

                var _target = _cam.targetTexture;
                Texture2D texture = new Texture2D(_target.width, _target.height, TextureFormat.RGBA32, false);
                RenderTexture.active = _cam.targetTexture;
                texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0, false);
                texture.Apply();

                var pngData = texture.EncodeToPNG();
                if (pngData != null)
                    System.IO.File.WriteAllBytes(path, pngData);
            }
        }
    }
}
