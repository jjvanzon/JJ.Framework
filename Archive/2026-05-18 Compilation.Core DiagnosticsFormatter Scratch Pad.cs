// TODO: Rename to CommandEnum? Or just Command? or DotNetCommand?
// TODO: Rename to DotNetCommand (command enum rebuild maps to command build, which sounds ambiguous
// TODO: Rename to ExtraArgs



        /*if (hasCommand)
        {
            if (args.IsRebuild)
            {
                if (HasRe(enumText))
                {
                    return enumText;
                }
                else
                {
                    return (args.IsRebuild ? "(re)" : "") + enumText;
                }
            }
        }
        else
        {
            if (args.IsRebuild)
            {
                return enumText + "/(re)" + commandTrim;
            }
            else
            {
                return enumText + "/" + commandTrim;
            }
        }
        */


        Func<string?, string?>[] synonyms =
        [
            x => CommandDescriptor(undefined, x, false) 
        ];


        foreach (var nully in _textNullies)
        {
        }
