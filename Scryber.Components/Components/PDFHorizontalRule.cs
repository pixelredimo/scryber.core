﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scryber.Drawing;
using Scryber.Styles;

namespace Scryber.Components
{
    [PDFParsableComponent("Hr")]
    [PDFJSConvertor("scryber.studio.design.convertors.pdf_hr")]
    public class PDFHorizontalRule : PDFLine
    {
        [PDFDesignable("Width", Ignore = true)]
        public override PDFUnit Width { get => base.Width; set => base.Width = value; }

        [PDFDesignable("Height", Ignore = true)]
        public override PDFUnit Height { get => base.Height; set => base.Height = value; }


        protected override PDFStyle GetBaseStyle()
        {

            PDFStyle style = base.GetBaseStyle();
            style.Size.FullWidth = true;

            return style;
        }
    }
}