=========================================================================================================================================
=== Magnetix packages ===================================================================================================================
=========================================================================================================================================

Magnetix.Data
	requires: Magnetix.Disposable
	requires: Magnetix.SystemTime
	requires: Magnetix.Extensions.AttributeExtensions
	requires: Magnetix.Extensions.EnumerableExtensions
	requires: Magnetix.Extensions.JoinStringExtensions
	requires: Magnetix.Reflection.AssemblyScanner

Magnetix.DirectoryServices
	requires: Magnetix.Linq.*
	requires: Magnetix.Reflection.ReflectionHelper

Magnetix.Linq
	requires: Magnetix.Extensions.TypeExtensions

Magnetix.Logging
	requires: Magnetix.SystemTime

Magnetix.Web.Modules.AccessDeniedRedirectModule

Magnetix.Web.Security.UserImpersonation

Magnetix.Web.WebControls.Adapters.DropDownListAdapter

Magnetix.Web.FileSystem

Magnetix.Web.HttpContextAdapter

Magnetix.Web.HttpHandlerBase
