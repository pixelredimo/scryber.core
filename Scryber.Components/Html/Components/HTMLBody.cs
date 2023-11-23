﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scryber.Components;
using Scryber.Styles;

namespace Scryber.Html.Components
{
    [PDFParsableComponent("body")]
    public class HTMLBody : Scryber.Components.Section
    {

        [PDFAttribute("class")]
        public override string StyleClass { get => base.StyleClass; set => base.StyleClass = value; }

        [PDFAttribute("style")]
        public override Style Style { get => base.Style; set => base.Style = value; }

        
        [PDFElement("")]
        [PDFArray(typeof(Component))]
        public override ComponentList Contents
        {
            get { return base.Contents; }
        }

        [PDFElement("header")]
        [PDFTemplate(IsBlock= true)]
        public override ITemplate Header { get => base.Header; set => base.Header = value; }

        [PDFElement("footer")]
        [PDFTemplate(IsBlock = true)]
        public override ITemplate Footer { get => base.Footer; set => base.Footer = value; }

        [PDFElement("continuation-header")]
        [PDFTemplate(IsBlock = true)]
        public override ITemplate ContinuationHeader { get => base.ContinuationHeader; set => base.ContinuationHeader = value; }

        [PDFElement("continuation-footer")]
        [PDFTemplate(IsBlock = true)]
        public override ITemplate ContinuationFooter { get => base.ContinuationFooter; set => base.ContinuationFooter = value; }

        /// <summary>
        /// Global Html hidden attribute used with xhtml as hidden='hidden'
        /// </summary>
        [PDFAttribute("hidden")]
        public string Hidden
        {
            get
            {
                if (this.Visible)
                    return string.Empty;
                else
                    return "hidden";
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value != "hidden")
                    this.Visible = true;
                else
                    this.Visible = false;
            }
        }

        [PDFAttribute("title")]
        public override string OutlineTitle
        {
            get => base.OutlineTitle;
            set => base.OutlineTitle = value;
        }

        public HTMLBody()
            : this(HTMLObjectTypes.Body)
        {
            
        }

        protected HTMLBody(ObjectType type): base(type)
        {

        }
    }
}
