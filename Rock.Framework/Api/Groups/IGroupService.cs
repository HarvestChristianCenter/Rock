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
        Rock.Models.Groups.Group GetGroup( string id );

        [OperationContract]
        void UpdateGroup( string id, Rock.Models.Groups.Group Group );

        [OperationContract]
        void CreateGroup( Rock.Models.Groups.Group Group );

        [OperationContract]
        void DeleteGroup( string id );
    }
}
