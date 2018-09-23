using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddedWindows : EditorWindow {

    //Adding a way to create a small memopad in Unity so I don't have to open up Notepad every time I think of something

    string myString = "";
    string memoName = ""; 

    [MenuItem("Window/Memopad %q")]
    public static void ShowMemopad()
    {
        GetWindow<AddedWindows>("Memopad");
    }

    void OnGUI()
    {
        GUILayout.Label("Use this space to write down your thoughts as they come to you while programming", EditorStyles.boldLabel);

        GUILayout.Label("Memo Name:");
        memoName = EditorGUILayout.TextField(memoName);
        GUILayout.Label("Memo Contents:");
        myString = EditorGUILayout.TextArea(myString);

        if (GUILayout.Button("Save Memo"))
        {
            //stores current memo in Unity project as txt file
            System.IO.File.AppendAllText("C:\\Users\\mmiel\\DoodleStudio95TestProject\\Assets\\Memos\\" + memoName + ".txt", "\r\n" + myString);

            //deletes the contents of the memo block so it can be typed in again
            myString = "";
        }

        if (GUILayout.Button("Clear Name"))
        {
            //clears out name so you can write up a new memo
            memoName = ""; 
        }
    }

    void OnLostFocus()
    {
         
    }



}
