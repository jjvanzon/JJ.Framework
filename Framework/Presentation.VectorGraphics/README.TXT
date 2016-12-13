JJ.Framework.Presentation.VectorGraphics is an API for specifying shapes, text and other graphical objects.

All graphics elements have the Diagram object as a root.

The graphical objects have mouse and keyboard gestures, basic styling, Z-order and parent-child relationships.

The gesture system allows you to introduce complex, composite gestures. For instance the framework already specifies gestures for moving around elements and basic drag-and-drop functionality.

The graphics can be scaled, and there are color helpers.

The objects are not actually drawn on screen until you also use JJ.Framework.Presentation.Drawing or JJ.Framework.Presentation.WinForms. This model simply offers an intuitive platform-independent model for vector graphics. To actually use it, use the aforementioned libraries.

The number of vector graphics elements is a bit limited for now. For instance, it does not contain circles or ellipses. It does offer bezier curves, though. Only the elements needed at the time were programmed.