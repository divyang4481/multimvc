This framework enables to create extendable multi tenant applications that can be custumised for every customer without making any changes to the core website.

Original vision is explained on the following blog post:
http://www.belgianagencies.com/blog.mvc/DisplayPost?postID=12

This framework can be used to create extendable multi-tenant applications that can be customised through the use of plugins without making any changes to the core website.

When a user request a page under the customer root folder
e.g: http://multitenant-site.com/[TenantKey]/[controller]/[action]
the framework looks for an assembly plug-in prefixed with the current tenant key and for visual plugins under the Extension folder. If no plugin is found it's the normal view or controller that's loaded.

Plugins can take two forms:

> -Visual Plugins: Are Views or other type of visual content that should replace the default visual content. These must be placed  under the extensions folder. To extend an application you copy the views under : \\[Root](Root.md)\Extensions\[Name](Tenant.md)\Views\[ControllerName](ControllerName.md)
e.g. c:\my projects\my website\extensions\contoso\home\index.cshtml

Other visual plugins like css goes under:Other form of visual plugins like css files or images must go under: \\[Root](Root.md)\Extensions\[Name](Tenant.md)\Content
e.g. c:\my projects\my website\Extensions\Contoso\Content\site.css

> -Assembly plugins: are assemblies containing Controllers,Services or Domain types.
Every type within the assembly should be prefixed with the TenantKey: e.g.: AdventureworksHomeController.  All plugin assemblies can simply be put under the bin folder.

MultiMVC comes also with a support for multi language sites and it uses an ultra light CMS feature.  Text or any other type of resource that can be retrieved by implementing the IRessourceRepository interface can be loaded from the Ressource property of the controller.
