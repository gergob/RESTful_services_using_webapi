#Installation Instructions

##1. Remove the Bootstrap package

1. Remove the default Bootstrap style:

From the package manager console run **`PM> Uninstall-Package Bootstrap`**

Rename `~/Content/Site.css` to `Site.css.exclude` **or delete the file**

##2. You are now ready to begin building your MVC project using Foundation.

####Related Nuget packages
Want to rapid prototype and wire frame directly from code using Html Helpers? 
Try the prototyping package on nuget. It works great with Foundation.
http://www.nuget.org/packages/Prototyping_MVC

Having trouble with media queries? Debug them with this simple CSS file.
http://nuget.org/packages/CSS_Media_Query_Debugger

####Documentation
Docs http://foundation.zurb.com/docs/  
Demo http://edcharbeneau.github.com/FoundationSinglePageRWD/

Resources: http://www.responsiveMVC.net/

Follow us:  
Ed Charbeneau http://twitter.com/#!/edcharbeneau  
Foundation Zurb http://twitter.com/#!/foundationzurb

#####Change Log:
Version 2.0.550
    - Updated Foundation to 5.5 (http://foundation.zurb.com/docs/changelog.html)

Version 2.0.540
    - Updated Foundation to 5.4

Version 2.0.530 
    - Updated Foundation to 5.3.0 (Foundation for Sites) http://zurb.com/article/1316/foundation-strike-5-3-strike-for-sites

Version 1.0.522
    - Updated Foundation to 5.2.2
    
Version 1.0.521
    - Updated Foundation to 5.2.1

Version 1.0.511
    - Updated Foundation to 5.1.1
    - Streamlinied the install process. Foundation will now overwrite the necessary files to minimize setup.

Version 1.0.502
	- Initial NuGet Release

Note: version scheme `<major>.<minor>.<foundation version>`
foundation version represents the foundation version less the "." for example 4.1.4 would be #.#.414

Foundation Framework Support:
http://foundation.zurb.com/docs