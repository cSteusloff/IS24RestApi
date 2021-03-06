//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 1.0.31.0.
namespace IS24RestApi.Search.Region
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// <para xml:lang="de-DE">Definiert eine Region mit allen verfügbaren Informationen.</para>
    /// <para xml:lang="en">Defines an region with all informations.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.31.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("Region", Namespace="http://rest.immobilienscout24.de/schema/search/region/1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Region
    {
        
        /// <summary>
        /// <para xml:lang="de-DE">Der Name der Region, entweder ein Bundesland, Stadt oder Stadtbezirk.</para>
        /// <para xml:lang="en">The name of the region, like a region, city or quarter.</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="string")]
        public string Name { get; set; }
        
        /// <summary>
        /// <para xml:lang="de-DE">Der IS24 GeoCode der Region.</para>
        /// <para xml:lang="en">The IS24 GeoCode of the region.</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("geoCodeId", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="long")]
        public long GeoCodeId { get; set; }
        
        /// <summary>
        /// <para xml:lang="de-DE">Die Anzahl der Objekte in dieser Region.</para>
        /// <para xml:lang="en">The amout of the objects in this region.</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("amount", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="int")]
        public int Amount { get; set; }
    }
    
    /// <summary>
    /// <para xml:lang="de-DE">Repräsentiert eine Liste alle Regionen.</para>
    /// <para xml:lang="en">Represents a list of regions.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "1.0.31.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("regions", Namespace="http://rest.immobilienscout24.de/schema/search/region/1.0", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("regions", Namespace="http://rest.immobilienscout24.de/schema/search/region/1.0")]
    public partial class Regions
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Region> _region;
        
        /// <summary>
        /// <para xml:lang="de-DE">Eine Region mit Angabe von Namen, geoCodeId und Anzahl Objekte.</para>
        /// <para xml:lang="en">A region with name, geoCodeId and amount.</para>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("region", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Collections.ObjectModel.Collection<Region> Region
        {
            get
            {
                return this._region;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Region-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Region collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RegionSpecified
        {
            get
            {
                return (this.Region.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="Regions" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="Regions" /> class.</para>
        /// </summary>
        public Regions()
        {
            this._region = new System.Collections.ObjectModel.Collection<Region>();
        }
    }
}
