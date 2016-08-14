Habitat for FXM

This fork of Habitat demonstrates various techniques that can be used to extend and simplify Sitecore's FXM capability:

* Placeholder Rendering Extension - A rendering that can be used from a FXM placeholder to render an item with a layout and nested placeholders.
* Prepend CSS Selector Transform - A transform that can be used from the FXM bundling pipeline to prepend a unique selector to all style rules in a bundle, thus preventing collisions with the host site's native stlyes.
* JavaScript Event Handlers - JavaScript event handlers that are normally initialized via the document ready event are extended to accomodate the FXM beacon's ready event.
* Item Urls - The Url method of the ItemExtension class is enhanced to provide the correct options to the LinkManager when the item is rendering in the context of an FXM placeholder

