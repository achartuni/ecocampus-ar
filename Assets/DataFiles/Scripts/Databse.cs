using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Databse : MonoBehaviour
{

    public static ArrayList modelList = new ArrayList();
    public static ArrayList audioList = new ArrayList();
    public static ArrayList longTextList = new ArrayList();
    public static ArrayList imageList = new ArrayList();
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    protected virtual void Start()
    {
        modelList.Clear();
        modelList.Add("First");
        audioList.Clear();
        audioList.Add("First");
        longTextList.Clear();
        longTextList.Add("First");
        imageList.Clear();
        imageList.Add("First");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();

            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://ecocampusar-3dacc.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        StartListener();
    }

    protected void StartListener()
    {
        FirebaseDatabase.DefaultInstance
          .GetReference("Ids").OrderByChild("id")
          .ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
              if (e2.DatabaseError != null)
              {
                  Debug.LogError(e2.DatabaseError.Message);
                  return;
              }
              Debug.Log("Received values for trees");
              string title = modelList[0].ToString();
              modelList.Clear();
              modelList.Add(title);

              string title2 = audioList[0].ToString();
              audioList.Clear();
              audioList.Add(title2);

              string title3 = longTextList[0].ToString();
              longTextList.Clear();
              longTextList.Add(title3);

              string title4 = imageList[0].ToString();
              imageList.Clear();
              imageList.Add(title4);

              if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
              {
                  foreach (var childSnapshot in e2.Snapshot.Children)
                  {
                      if (childSnapshot.Child("id") == null
                    || childSnapshot.Child("id").Value == null)
                      {
                          Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
                          break;
                      }
                      else
                      {
                          modelList.Insert(1, childSnapshot.Child("text").Value.ToString());
                          audioList.Insert(1, childSnapshot.Child("audioUrl").Value.ToString());
                          longTextList.Insert(1, childSnapshot.Child("treeLongText").Value.ToString());
                          imageList.Insert(1, childSnapshot.Child("imgUrl").Value.ToString());
                      }
                  }
              }
          };
    }
}

