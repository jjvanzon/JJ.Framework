# JJ.Framework.Drawing

Is mostly about mapping JJ.Framework.VectorGraphics to System.Drawing, making that Vector Graphics API usable with System.Drawing.

But it also contains a class GraphicsBuffer, which allows you to draw graphics in a buffer, and only if you are done, draw the result to the target Graphics. This allows you to create smoothly drawn graphics with System.Drawing.