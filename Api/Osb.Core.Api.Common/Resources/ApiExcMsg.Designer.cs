﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Osb.Core.Api.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ApiExcMsg {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ApiExcMsg() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Osb.Core.Api.Common.Resources.ApiExcMsg", typeof(ApiExcMsg).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to É necessário informar a versão da API.
        /// </summary>
        public static string ApiExc0001 {
            get {
                return ResourceManager.GetString("ApiExc0001", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to É necessário informar o Token.
        /// </summary>
        public static string ApiExc0002 {
            get {
                return ResourceManager.GetString("ApiExc0002", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Header &apos;businessUnitId&apos; é obrigatório.
        /// </summary>
        public static string ApiExc0003 {
            get {
                return ResourceManager.GetString("ApiExc0003", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Header &apos;partnerId&apos; é obrigatório.
        /// </summary>
        public static string ApiExc0004 {
            get {
                return ResourceManager.GetString("ApiExc0004", resourceCulture);
            }
        }
    }
}
