﻿using TinaX;
using TinaX.UIKit;
using TinaX.VFSKit;
using UnityEngine.Rendering.Universal;

namespace Nekonya.Example
{
    /// <summary>
    /// 推荐作为App (Game) 的程序入口。该class会被TinaX反射寻找，可以同时存在多个
    /// It is recommended to be the program entry of app (game). 
    /// This class will be reflection by tinax , and there can be multiple
    /// </summary>
    public class AppBootstrap : IXBootstrap
    {
        /// <summary>
        /// "OnInit" be called after "TinaX's Services" Inited and Registered, before "TinaX's Services" started.
        /// </summary>
        public void OnInit(IXCore core) { }

        public void OnStart(IXCore core)
        {
            //open ui
            var uikit = core.GetService<IUIKit>();
            var uacd = uikit.UICamera.GetUniversalAdditionalCameraData();
            uacd.renderType = CameraRenderType.Overlay;
            uacd.renderShadows = false;
            uacd.volumeLayerMask = 1 << 5;
            MainCameraComponent.Instance.AddCamera(uikit.UICamera);

            _ = uikit.OpenUIAsync("mainScreen", new MainScreen());

            //load scene
            var vfs = core.GetService<IVFS>();
            vfs.LoadSceneAsync("Assets/App/Scenes/App.Main.unity",(scene, err) => 
            {
                scene.OpenScene();
            });
        }

        public void OnQuit() { }
        public void OnAppRestart() { }
    }
}
