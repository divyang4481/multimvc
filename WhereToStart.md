Have a look at the full blown sample application in the sample folder.  It uses NHibernate and Sql server as database but this is not a mandatory architecture for the framework.  If you've Sql server or sqlexpress 8.0 and you're sql admin on your pc it should create the DB of the default tenant automatically at application startup.

Every tenant has a connectionstring key beginning with db (have a look at the web.config file)but again this is not a Framework constraint.

When you navigate to: http://localhost:52436/Default.mvc
or http://localhost:52436/Bicycle.mvc/en you'll get another db connectionstring, load a specific controller and other view just because they are present.  When the framework does not detect controller or view overloads it simply load the defaults.
Views are registred in the extension folder and Controller or Domain or NHibernate mapping files should be compiled in separate library copied in the bin folder (have a look at the BackToOwner.Bicycle project post buil event).

The application determine the tenantid from the url ("{tenantKey}.mvc/{language}/{controller}/{action}/{id}", have a look at the route declaration in the global.asax.

The application also exposes Rest services that are tenant aware- I'm still working on this part.