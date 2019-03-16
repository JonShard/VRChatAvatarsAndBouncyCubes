using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VRCSDK2
{
    [InitializeOnLoad]
    public class VRC_SdkSplashScreen : EditorWindow
    {

        static VRC_SdkSplashScreen()
        {
            EditorApplication.update -= DoSplashScreen;
            EditorApplication.update += DoSplashScreen;
        }

        private static void DoSplashScreen()
        {
            EditorApplication.update -= DoSplashScreen;
            if (!EditorPrefs.HasKey("VRCSDK_ShowSplashScreen"))
            {
                EditorPrefs.SetBool("VRCSDK_ShowSplashScreen", true);
            }
            if (EditorPrefs.GetBool("VRCSDK_ShowSplashScreen"))
                OpenSplashScreen();
        }

        private static GUIStyle vrcSdkHeader;
        //private static GUIStyle vrcLinkButton;
        private static Vector2 changeLogScroll;
        [MenuItem("Odds SDK/Splash Screen|Changelog", false, 500)]
        public static void OpenSplashScreen()
        {
            GetWindow<VRC_SdkSplashScreen>(true);
        }
        
        public static void Open()
        {
            OpenSplashScreen();
        }

        public void OnEnable()
        {


            titleContent = new GUIContent("Odds SDK");

            maxSize = new Vector2(400, 650);
            minSize = maxSize;

            vrcSdkHeader = new GUIStyle
            {
                normal =
                    {
                        background = Resources.Load("vrcSdkHeader") as Texture2D,
                        textColor = Color.white
                    },
                fixedHeight = 200
            };

            //vrcLinkButton = EditorStyles.miniButton;
            //vrcLinkButton.normal.textColor = new Color(0, 42f/255f,1);
        }

        public void OnGUI()
        {
            GUILayout.Box("", vrcSdkHeader);

            GUILayout.Space(4);
            GUILayout.BeginHorizontal();
            GUI.backgroundColor = Color.cyan;
            if (GUILayout.Button("Discord"))
            {
                Application.OpenURL("http://oddz.xyz");
            }
            if (GUILayout.Button("SDK Link"))
            {
                Application.OpenURL("http://sdk.oddz.xyz");
            }
            if (GUILayout.Button("VRChat Site"))
            {
                Application.OpenURL("https://vrchat.net");
            }
            GUI.backgroundColor = Color.grey;
            GUILayout.EndHorizontal();
            GUILayout.Space(4);

            changeLogScroll = GUILayout.BeginScrollView(changeLogScroll);
            GUILayout.Label(
    @"Welcome to Odds Custom SDK v9!
Can reach me on my discord here: odds#0001


 * Changelog v9:
-> Updated to latest SDK-2018.12.19.17.03
- Cleaned up beta stuff.

 * Changelog v8 (Beta):
-> Updated to latest SDK-2018.11.15.12.19
Added following options to 'settings':
-Add VRC Collision Layers : 
(Adds VRChats collision layers to your project)
- Import DynamicBones : 
(Imports DynamicBones into your project)
- Import Cubed Shaders : 
(Imports Cubed Shaders into your project)
- Import Poiyomi Master Shader : 
(Imports Poiyomi Master Shader into your project)

* Changelog v7:
 -> Updated to latest SDK-2018.08.23.11.02
 -> Changed a couple buttons in the splash screen
 -> Finally moved Clear Cache and PlayerPrefs to Odds SDK
 -> Cleaned up some unused stuff
 - Removed annoying/unnecesary warnings.
 - Removed audio limit.
 - Removed poly limit.
 - Allowed scripts/event handler. (Was used for chairs)
 - Removed height limit.
 - Changed Build & Publish to Upload Avatar
 - Removed annoying unity version check.
 - Removed warnings related to cameras.
 - Removed warnings related to audio sources.
 - Added auto viseme detection.
 - Added custom changelog/splash screen
 - Moved following options into Odds SDK:
 Splash Screen|Changelog
 Settings
 Force Configure Player Settings
 Uploaded Content
 Upload Panel"
            );
            GUILayout.EndScrollView();

            GUILayout.FlexibleSpace();

            GUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();
            EditorPrefs.SetBool("VRCSDK_ShowSplashScreen", GUILayout.Toggle(EditorPrefs.GetBool("VRCSDK_ShowSplashScreen"), "Show at Startup"));

            GUILayout.EndHorizontal();
        }

    }
}