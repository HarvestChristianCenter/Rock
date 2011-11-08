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

		[WebGet( UriTemplate = "Person/{id}" )]
        public Rock.Models.Crm.Person GetPerson( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Crm.PersonService PersonService = new Rock.Services.Crm.PersonService();
                Rock.Models.Crm.Person Person = PersonService.GetPerson( int.Parse( id ) );
                if ( Person.Authorized( "View", currentUser ) )
                    return Person;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		[WebInvoke( Method = "PUT", UriTemplate = "Person/{id}" )]
        public void UpdatePerson( string id, Rock.Models.Crm.Person Person )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Crm.PersonService PersonService = new Rock.Services.Crm.PersonService();
                Rock.Models.Crm.Person existingPerson = PersonService.GetPerson( int.Parse( id ) );
                if ( existingPerson.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingPerson).CurrentValues.SetValues(Person);
                    PersonService.Save( existingPerson, ( int )currentUser.ProviderUserKey );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		[WebInvoke( Method = "POST", UriTemplate = "Person" )]
        public void CreatePerson( Rock.Models.Crm.Person Person )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Crm.PersonService PersonService = new Rock.Services.Crm.PersonService();
                PersonService.AttachPerson( Person );
                PersonService.Save( Person, ( int )currentUser.ProviderUserKey );
            }
        }

		[WebInvoke( Method = "DELETE", UriTemplate = "Person/{id}" )]
        public void DeletePerson( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Crm.PersonService PersonService = new Rock.Services.Crm.PersonService();
                Rock.Models.Crm.Person Person = PersonService.GetPerson( int.Parse( id ) );
                if ( Person.Authorized( "Edit", currentUser ) )
                {
                    PersonService.DeletePerson( Person );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}
