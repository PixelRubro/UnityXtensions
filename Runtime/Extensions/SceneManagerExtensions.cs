// using UnityEngine;
// using System.Collections;

// namespace SoftBoiledGames.UnityXtensions
// {
//     public class SceneManagerExtensions 
//     {
//         /// <summary>
//         /// Returns all loaded scenes.
//         /// </summary>
//         /// <returns>All loaded scenes.</returns>
//         public static List<Scene> GetAllLoadedScenes(this SceneManager self)
//         {
//             var scenes = new List<Scene>();

//             for (var i = 0; i < SceneManager.sceneCount; i++)
//             {
//                 scenes.Add(SceneManager.GetSceneAt(i));
//             }

//             return scenes;
//         }
//     }
// }