﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace algorithmsRepresentation.ImplSimpleGraph {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class GraphResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GraphResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("algorithmsRepresentation.ImplSimpleGraph.GraphResource", typeof(GraphResource).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nieprawidłowe dane!.
        /// </summary>
        internal static string AddEdge_AdjacencyMatrix_WrongData {
            get {
                return ResourceManager.GetString("AddEdge_AdjacencyMatrix_WrongData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Graf nie ma podanych wieszchołków!.
        /// </summary>
        internal static string AddEdge_MissingVertex {
            get {
                return ResourceManager.GetString("AddEdge_MissingVertex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Taki wieszchołek już instnieje!.
        /// </summary>
        internal static string AddVertex_AdjacencyList_ExistingVertex {
            get {
                return ResourceManager.GetString("AddVertex_AdjacencyList_ExistingVertex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Taka krawędź nie istneije!.
        /// </summary>
        internal static string AdjacencyList_GetWeight_NoExsistEdge {
            get {
                return ResourceManager.GetString("AdjacencyList_GetWeight_NoExsistEdge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Błędne dane w pliku JSON - nie można zlokalizować &quot;matrix&quot;.
        /// </summary>
        internal static string ConverterAdjacencyMatrix_JsonToGraph_WrongData {
            get {
                return ResourceManager.GetString("ConverterAdjacencyMatrix_JsonToGraph_WrongData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wybrany wieszchołek początkowy lub dolecowy nie istnieje!.
        /// </summary>
        internal static string DijkstraA_FindPath_VertexDoNotExsist {
            get {
                return ResourceManager.GetString("DijkstraA_FindPath_VertexDoNotExsist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Podany wieszchołek nie istnieje!.
        /// </summary>
        internal static string GetVertex_VertexDontExist {
            get {
                return ResourceManager.GetString("GetVertex_VertexDontExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Krawędź: ({0}, {1}): waga {2}.
        /// </summary>
        internal static string PrintGraph_Text {
            get {
                return ResourceManager.GetString("PrintGraph_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wieszchołek {0}: .
        /// </summary>
        internal static string PrintGraph_VertexGraph_Vertex {
            get {
                return ResourceManager.GetString("PrintGraph_VertexGraph_Vertex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: waga {1} .
        /// </summary>
        internal static string PrintGraph_VertexGraph_VertexWeight {
            get {
                return ResourceManager.GetString("PrintGraph_VertexGraph_VertexWeight", resourceCulture);
            }
        }
    }
}
