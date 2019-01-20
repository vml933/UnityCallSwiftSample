using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class SwiftPostProcess
{

    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
    {
        var projPath = buildPath + "/Unity-Iphone.xcodeproj/project.pbxproj";
        var proj = new PBXProject();
        proj.ReadFromFile(projPath);

        var targetGuid = proj.TargetGuidByName(PBXProject.GetUnityTargetName());

        proj.SetBuildProperty(targetGuid, "ENABLE_BITCODE", "NO");
        //swift要使用ojbc的class時用到
        proj.SetBuildProperty(targetGuid, "SWIFT_OBJC_BRIDGING_HEADER", "Libraries/Plugins/iOS/SwiftPlugin/Source/SwiftPlugin-Bridging-Header.h");
        //ojbc要使用swift class時用到
        proj.SetBuildProperty(targetGuid, "SWIFT_OBJC_INTERFACE_HEADER_NAME", "SwiftPlugin-Swift.h");
        //上面兩個設定似乎要讓unity認得swift檔案，
        //因為在原生objc的專案，在.m檔案中import porject name-swift 會認得swift的方式, 在unity輸出的xcode專案會無效

        proj.AddBuildProperty(targetGuid, "LD_RUNPATH_SEARCH_PATHS", "@executable_path/Frameworks $(PROJECT_DIR)/lib/$(CONFIGURATION) $(inherited)");
        //proj.AddBuildProperty(targetGuid, "FRAMERWORK_SEARCH_PATHS", "$(inherited) $(PROJECT_DIR) $(PROJECT_DIR)/Frameworks");
        //proj.AddBuildProperty(targetGuid, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
        //proj.AddBuildProperty(targetGuid, "DYLIB_INSTALL_NAME_BASE", "@rpath");
        //proj.AddBuildProperty(targetGuid, "LD_DYLIB_INSTALL_NAME", "@executable_path/../Frameworks/$(EXECUTABLE_PATH)");
        proj.AddBuildProperty(targetGuid, "DEFINES_MODULE", "YES");
        proj.AddBuildProperty(targetGuid, "SWIFT_VERSION", "4.0");

        proj.WriteToFile(projPath);
    }
}
