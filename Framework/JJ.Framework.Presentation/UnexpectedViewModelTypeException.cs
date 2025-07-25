﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Framework.Presentation.Legacy
{
    public class UnexpectedViewModelTypeException : Exception
    {
        private const string MESSAGE = "Unexpected view model type: '{0}'.";

        private readonly object _viewModel; 

        public UnexpectedViewModelTypeException(object viewModel)
        {
            _viewModel = viewModel;
        }

        public override string Message
        {
            get
            {
                string viewModelTypeDescription;
                if (_viewModel == null)
                {
                    viewModelTypeDescription = "<null>";
                }
                else
                {
                    viewModelTypeDescription = _viewModel.GetType().FullName;
                }

                return String.Format(MESSAGE, viewModelTypeDescription);
            }
        }
    }
}