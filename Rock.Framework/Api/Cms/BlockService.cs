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
using System.ServiceModel.Web;

namespace Rock.Api
{
    public partial class Service
    {

		[WebGet( UriTemplate = "Block/{id}" )]
        public Rock.Models.Cms.Block GetBlock( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Cms.BlockService BlockService = new Rock.Services.Cms.BlockService();
                Rock.Models.Cms.Block Block = BlockService.GetBlock( int.Parse( id ) );
                if ( Block.Authorized( "View", currentUser ) )
                    return Block;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		[WebInvoke( Method = "PUT", UriTemplate = "Block/{id}" )]
        public void UpdateBlock( string id, Rock.Models.Cms.Block Block )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.BlockService BlockService = new Rock.Services.Cms.BlockService();
                Rock.Models.Cms.Block existingBlock = BlockService.GetBlock( int.Parse( id ) );
                if ( existingBlock.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingBlock).CurrentValues.SetValues(Block);
                    BlockService.Save( existingBlock, ( int )currentUser.ProviderUserKey );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		[WebInvoke( Method = "POST", UriTemplate = "Block" )]
        public void CreateBlock( Rock.Models.Cms.Block Block )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.BlockService BlockService = new Rock.Services.Cms.BlockService();
                BlockService.AttachBlock( Block );
                BlockService.Save( Block, ( int )currentUser.ProviderUserKey );
            }
        }

		[WebInvoke( Method = "DELETE", UriTemplate = "Block/{id}" )]
        public void DeleteBlock( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.BlockService BlockService = new Rock.Services.Cms.BlockService();
                Rock.Models.Cms.Block Block = BlockService.GetBlock( int.Parse( id ) );
                if ( Block.Authorized( "Edit", currentUser ) )
                {
                    BlockService.DeleteBlock( Block );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}
