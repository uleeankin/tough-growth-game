﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Model.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Выход.
        /// </summary>
        internal static string ExitControlItem {
            get {
                return ResourceManager.GetString("ExitControlItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Начать игру.
        /// </summary>
        internal static string GameControlItem {
            get {
                return ResourceManager.GetString("GameControlItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на info\\GameRules.txt.
        /// </summary>
        internal static string GameRulesFileName {
            get {
                return ResourceManager.GetString("GameRulesFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Справка.
        /// </summary>
        internal static string InfoControlItem {
            get {
                return ResourceManager.GetString("InfoControlItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Главное меню.
        /// </summary>
        internal static string MainMenuControlItem {
            get {
                return ResourceManager.GetString("MainMenuControlItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на info\\ManagementRules.txt.
        /// </summary>
        internal static string ManagementRulesFileName {
            get {
                return ResourceManager.GetString("ManagementRulesFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Рекорды.
        /// </summary>
        internal static string RecordsControlItem {
            get {
                return ResourceManager.GetString("RecordsControlItem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на TOUGH GROWTH.
        /// </summary>
        internal static string TitlePassiveItem {
            get {
                return ResourceManager.GetString("TitlePassiveItem", resourceCulture);
            }
        }
    }
}
