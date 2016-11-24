using System;
using System.Collections.Generic;
using System.Text;
using AopDraw.Interfaces;

namespace AopDraw.Mixins
{
    public class GuidObject : IGuidObject
    {
        private string guid;
        public string Guid
        {
            get
            {
                return this.guid;
            }
        }

        public GuidObject()
        {
            this.guid = System.Guid.NewGuid().ToString();
        } 
    }
}
