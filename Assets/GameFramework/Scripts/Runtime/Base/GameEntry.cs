//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public class GameEntry:MonoBehaviour
    {
        private static readonly GameFrameworkLinkedList<GameFrameworkComponent> s_GameFrameworkComponents = new GameFrameworkLinkedList<GameFrameworkComponent>();

        /// <summary>
        /// 游戏框架所在的场景编号。
        /// </summary>
        internal const int GameFrameworkSceneId = 0;

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <typeparam name="T">要获取的游戏框架组件类型。</typeparam>
        /// <returns>要获取的游戏框架组件。</returns>
        public static new T GetComponent<T>() where T : GameFrameworkComponent
        {
            return (T)GetComponent(typeof(T));
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <param name="type">要获取的游戏框架组件类型。</param>
        /// <returns>要获取的游戏框架组件。</returns>
        public static new GameFrameworkComponent GetComponent(Type type)
        {
            LinkedListNode<GameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current != null)
            {
                if (current.Value.GetType() == type)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <param name="typeName">要获取的游戏框架组件类型名称。</param>
        /// <returns>要获取的游戏框架组件。</returns>
        public static new GameFrameworkComponent GetComponent(string typeName)
        {
            LinkedListNode<GameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current != null)
            {
                Type type = current.Value.GetType();
                if (type.FullName == typeName || type.Name == typeName)
                {
                    return current.Value;
                }

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// 关闭游戏框架。
        /// </summary>
        /// <param name="shutdownType">关闭游戏框架类型。</param>
        public static void Shutdown(ShutdownType shutdownType)
        {
            Log.Info("Shutdown Game Framework ({0})...", shutdownType.ToString());
            BaseComponent baseComponent = GetComponent<BaseComponent>();
            if (baseComponent != null)
            {
                baseComponent.Shutdown();
                baseComponent = null;
            }

            s_GameFrameworkComponents.Clear();

            if (shutdownType == ShutdownType.None)
            {
                return;
            }

            if (shutdownType == ShutdownType.Restart)
            {
                SceneManager.LoadScene(GameFrameworkSceneId);
                return;
            }

            if (shutdownType == ShutdownType.Quit)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                return;
            }
        }

        /// <summary>
        /// 注册游戏框架组件。
        /// </summary>
        /// <param name="gameFrameworkComponent">要注册的游戏框架组件。</param>
        internal static void RegisterComponent(GameFrameworkComponent gameFrameworkComponent)
        {
            if (gameFrameworkComponent == null)
            {
                Log.Error("Game Framework component is invalid.");
                return;
            }

            Type type = gameFrameworkComponent.GetType();

            LinkedListNode<GameFrameworkComponent> current = s_GameFrameworkComponents.First;
            while (current != null)
            {
                if (current.Value.GetType() == type)
                {
                    Log.Error("Game Framework component type '{0}' is already exist.", type.FullName);
                    return;
                }

                current = current.Next;
            }

            s_GameFrameworkComponents.AddLast(gameFrameworkComponent);
        }


        /// <summary>
        /// 获取游戏基础组件。
        /// </summary>
        public static BaseComponent Base
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置组件。
        /// </summary>
        public static ConfigComponent Config
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据结点组件。
        /// </summary>
        public static DataNodeComponent DataNode
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表组件。
        /// </summary>
        public static DataTableComponent DataTable
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取调试组件。
        /// </summary>
        public static DebuggerComponent Debugger
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载组件。
        /// </summary>
        public static DownloadComponent Download
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体组件。
        /// </summary>
        public static EntityComponent Entity
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取事件组件。
        /// </summary>
        public static EventComponent Event
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取文件系统组件。
        /// </summary>
        public static FileSystemComponent FileSystem
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取有限状态机组件。
        /// </summary>
        public static FsmComponent Fsm
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取本地化组件。
        /// </summary>
        public static LocalizationComponent Localization
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取网络组件。
        /// </summary>
        public static NetworkComponent Network
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取对象池组件。
        /// </summary>
        public static ObjectPoolComponent ObjectPool
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取流程组件。
        /// </summary>
        public static ProcedureComponent Procedure
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源组件。
        /// </summary>
        public static ResourceComponent Resource
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取场景组件。
        /// </summary>
        public static SceneComponent Scene
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置组件。
        /// </summary>
        public static SettingComponent Setting
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取声音组件。
        /// </summary>
        public static SoundComponent Sound
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取界面组件。
        /// </summary>
        public static UIComponent UI
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取网络组件。
        /// </summary>
        public static WebRequestComponent WebRequest
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始化组件
        /// </summary>
        private static void InitBuiltinComponents()
        {
            Base = UnityGameFramework.Runtime.GameEntry.GetComponent<BaseComponent>();
            Config = UnityGameFramework.Runtime.GameEntry.GetComponent<ConfigComponent>();
            DataNode = UnityGameFramework.Runtime.GameEntry.GetComponent<DataNodeComponent>();
            DataTable = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();
            Debugger = UnityGameFramework.Runtime.GameEntry.GetComponent<DebuggerComponent>();
            Download = UnityGameFramework.Runtime.GameEntry.GetComponent<DownloadComponent>();
            Entity = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();
            Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
            FileSystem = UnityGameFramework.Runtime.GameEntry.GetComponent<FileSystemComponent>();
            Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();
            Localization = UnityGameFramework.Runtime.GameEntry.GetComponent<LocalizationComponent>();
            Network = UnityGameFramework.Runtime.GameEntry.GetComponent<NetworkComponent>();
            ObjectPool = UnityGameFramework.Runtime.GameEntry.GetComponent<ObjectPoolComponent>();
            Procedure = UnityGameFramework.Runtime.GameEntry.GetComponent<ProcedureComponent>();
            Resource = UnityGameFramework.Runtime.GameEntry.GetComponent<ResourceComponent>();
            Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
            Setting = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();
            Sound = UnityGameFramework.Runtime.GameEntry.GetComponent<SoundComponent>();
            UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
            WebRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
        }

        private void Start()
        {
            InitBuiltinComponents();
        }
    }
}
