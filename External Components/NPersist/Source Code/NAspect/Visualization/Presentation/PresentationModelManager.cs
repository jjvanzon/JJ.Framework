using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationModelManager
    {
        public static PresentationModel CreatePresentationModel(IEngine engine)
        {
            PresentationModel model = new PresentationModel();
            foreach (IGenericAspect aspect in engine.Configuration.Aspects)
            {
                PresentationAspect presAspect = new PresentationAspect(aspect);
                model.Aspects.Add(presAspect);
            }

            return model;
        }
    }
}
