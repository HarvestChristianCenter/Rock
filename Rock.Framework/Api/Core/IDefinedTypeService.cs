//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.ServiceModel;

namespace Rock.Api
{
    public partial interface IService
    {
		[OperationContract]
        Rock.Models.Core.DefinedType GetDefinedType( string id );

        [OperationContract]
        void UpdateDefinedType( string id, Rock.Models.Core.DefinedType DefinedType );

        [OperationContract]
        void CreateDefinedType( Rock.Models.Core.DefinedType DefinedType );

        [OperationContract]
        void DeleteDefinedType( string id );
    }
}
